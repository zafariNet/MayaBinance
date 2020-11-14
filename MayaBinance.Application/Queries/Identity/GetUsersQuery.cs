using System.Collections.Generic;
using MayaBinance.Application.Dtos.Identity;
using MayaBinance.Domain;
using MediatR;

namespace MayaBinance.Application.Queries.Identity
{
    public class GetUsersQuery:IRequest<QueryResponse<List<SimpleUserViewModel>>>
    {

    }
}
