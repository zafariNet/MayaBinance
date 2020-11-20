using System.Collections.Generic;
using MayaBinance.Domain;
using MayaBinance.Domain.BaseModels.ViewModels;
using MediatR;

namespace MayaBinance.Application.Queries.BaseModels
{
    public class GetAllCoinsQuery:IRequest<QueryResponse<List<SimpleCoinsViewModel>>>
    {
        public bool IsActive { get; set; }
    }
}
