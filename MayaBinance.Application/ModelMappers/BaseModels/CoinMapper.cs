using MayaBinance.Application.Dtos.BaseModels;
using MayaBinance.Application.Queries.BaseModels;
using MayaBinance.Domain.BaseModels;
using MayaBinance.Domain.BaseModels.ViewModels;

namespace MayaBinance.Application.ModelMappers.BaseModels
{
    public class CoinMapper: AutoMapperBase
    {
        public CoinMapper()
        {
            CreateMap<GetAllCoinsRequest, GetAllCoinsQuery>();
            CreateMap<Coin, SimpleCoinsViewModel>().ReverseMap();
                
        }
    }
}
