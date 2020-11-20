using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MayaBinance.DataAccess.Repositories.Identity.Interfaces;
using MayaBinance.Domain;
using MayaBinance.Domain.Identity.Users;
using MediatR;

namespace MayaBinance.Application.Commands.Identity.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<CommandResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }


        public async Task<Result<CommandResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User(request.FirstName, request.LastName, request.EmailOrUserName,
                    request.Password, null);

                _userRepository.Insert(user);

                var result = await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                foreach (var notification in user.Events)
                {
                    await _mediator.Publish(notification, cancellationToken);
                }
                return Result.Success(new CommandResponse());
            }
            catch (Exception e)
            {
                var message = e.Message;
                
                if (e.InnerException != null) 
                    message=e.InnerException.Message;
                return Result.Failure<CommandResponse>(message);
            }
        }
    }
}
