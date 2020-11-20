using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MayaBinance.Application.Queries.BaseModels;
using MediatR;

namespace MayaBinance.Api.Controllers.BaseModels
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CoinsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllCoins")]
        public IActionResult GetAllCoins(bool? isActive)
        {
            var command=new GetAllCoinsQuery(){IsActive = isActive??true};
            var result=_mediator.Send(command);
            return GenerateResponse(result);
        }
    }

}
