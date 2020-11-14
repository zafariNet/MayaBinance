using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MayaBinance.Domain;
using MayaBinance.Domain.Identity.Users;
using MayaBinance.Domain.Identity.Users.DomainEvents;
using MediatR;

namespace MayaBinance.Application.Commands.Identity.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<CommandResponse>>
    {
        private readonly IUserRepository _baseRepository;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IUserRepository baseRepository, IMediator mediator)
        {
            _baseRepository = baseRepository;
            _mediator = mediator;
        }


        public async Task<Result<CommandResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User(request.FirstName, request.LastName, request.EmailOrUserName,
                    request.Password, null);

                _baseRepository.Insert(user);

                var result = await _baseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                foreach (var notification in user.Events)
                {
                    await _mediator.Publish(notification, cancellationToken);
                }
                return Result.Success<CommandResponse>(new CommandResponse());
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
