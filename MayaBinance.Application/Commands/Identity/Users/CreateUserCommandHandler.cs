using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MayaBinance.Domain.Identity.Users;
using MediatR;

namespace MayaBinance.Application.Commands.Identity.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IUserRepository _baseRepository;

        public CreateUserCommandHandler(IUserRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
             _baseRepository.Insert(new User(request.FirstName, request.LastName, request.EmailOrUserName,
                request.Password, null));
            var result = await _baseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return result;
        }
    }
}
