using System;
using MayaBinance.DataAccess.Context;
using MayaBinance.DataAccess.Infrastructures;
using MayaBinance.DataAccess.Repositories.Identity.Interfaces;
using MayaBinance.Domain.Identity.Users;

namespace MayaBinance.DataAccess.Repositories.Identity
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(MayaBinanceContext context):base(context)
        {
        }

    }
}
