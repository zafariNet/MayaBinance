using MayaBinance.DataAccess.Infrastructures;
using MayaBinance.Domain.BaseModels;
using MayaBinance.Domain.SeedWork;

namespace MayaBinance.DataAccess.Repositories.BaseModels.Interfaces
{
    public interface ICoinRepository:IRepositoryAsync<Coin>
    {
    }
}
