using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MayaBinance.Application.Commands.Identity.Users;
using MayaBinance.Application.Dtos.Identity;
using MayaBinance.Application.Queries.Identity;
using MayaBinance.Domain.Identity.Users;
using MediatR;

namespace MayaBinance.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserRepository _baseRepository;

        private readonly IMediator _mediator;
        public UserController(IUserRepository baseRepository, IMediator mediator)
        {
            _baseRepository = baseRepository;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var getUserQuery=new GetUsersQuery();
            var result =await _mediator.Send(getUserQuery);
            return GenerateResponse(result);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] CreateUserDto request)
        {
            var command = new CreateUserCommand(request.FirstName, request.LastName,
                request.EmailOrUserName, request.Password, null);
            var result = await _mediator.Send(command);
            return GenerateResponse(result);

        }
    }
}
