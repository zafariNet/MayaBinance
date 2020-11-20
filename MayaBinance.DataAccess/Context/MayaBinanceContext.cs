using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MayaBinance.DataAccess.ModelConfigurations.BaseModels;
using MayaBinance.DataAccess.ModelConfigurations.Identity;
using MayaBinance.Domain.BaseModels;
using MayaBinance.Domain.Identity.Users;
using MayaBinance.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using IUnitOfWork = MayaBinance.DataAccess.Infrastructures.IUnitOfWork;

namespace MayaBinance.DataAccess.Context
{
    public class MayaBinanceContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "Ordering";
        private IDbContextTransaction _currentTransaction;
        public DbSet<User> Users { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public MayaBinanceContext(DbContextOptions<MayaBinanceContext> options) :
            base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new
                UserConfig());
            modelBuilder.ApplyConfiguration(new CoinConfiguration());

        }
        public IDbContextTransaction GetCurrentTransaction() =>
            _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;
            _currentTransaction = await
                Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction
            transaction)
        {
            if (transaction == null)
                throw new
                    ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction)
                throw new
                    InvalidOperationException($"Transaction {transaction.TransactionId} is not current");
            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
        public async Task<Result> SaveEntitiesAsync(CancellationToken
            cancellationToken = default(CancellationToken))
        {
            try
            {
                var result=await base.SaveChangesAsync(cancellationToken);
                if(result>=1)
                    return Result.Success("");
                return Result.Failure("");
            }
            catch (Exception e)
            {
                Result.Failure(e.Message);
            }
            return Result.Failure("");
        }
    }
}
