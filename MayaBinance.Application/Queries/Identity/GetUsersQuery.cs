using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using MayaBinance.Application.Dtos;
using MayaBinance.Application.Dtos.Identity;
using MayaBinance.Domain;
using MediatR;

namespace MayaBinance.Application.Queries.Identity
{
    public class GetUsersQuery:IRequest<QueryResponse<List<SimpleUserViewModel>>>
    {

    }
}
