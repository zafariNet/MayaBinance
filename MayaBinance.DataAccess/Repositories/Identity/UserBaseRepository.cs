using System;
using MayaBinance.DataAccess.Context;
using MayaBinance.Domain.Identity.Users;

namespace MayaBinance.DataAccess.Repositories.Identity
{
    public class UserRepository:BaseRepository<Guid,User>,IUserRepository
    {
        public readonly MayaBinanceContext _context;
        public UserRepository(MayaBinanceContext context):base(context)
        {
            _context = context;
        }

    }
}
