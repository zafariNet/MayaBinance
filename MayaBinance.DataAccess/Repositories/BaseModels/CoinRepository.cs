using MayaBinance.DataAccess.Context;
using MayaBinance.DataAccess.Infrastructures;
using MayaBinance.DataAccess.Repositories.BaseModels.Interfaces;
using MayaBinance.Domain.BaseModels;

namespace MayaBinance.DataAccess.Repositories.BaseModels
{
    public class CoinRepository:Repository<Coin>,ICoinRepository
    {
        public CoinRepository(MayaBinanceContext context) : base(context)
        {
        }
    }
}
