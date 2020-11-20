using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MayaBinance.DataAccess.Repositories.BaseModels.Interfaces;
using MayaBinance.Domain;
using MayaBinance.Domain.BaseModels.ViewModels;
using MayaBinance.Shared.utils;
using MediatR;

namespace MayaBinance.Application.Queries.BaseModels
{
    public class GetAllCoinsHandler:IRequestHandler<GetAllCoinsQuery, QueryResponse<List<SimpleCoinsViewModel>>>
    {
        private readonly ICoinRepository _coinRepository;
        private readonly IMapper _mapper;

        public GetAllCoinsHandler(ICoinRepository coinRepository, IMapper mapper)
        {
            _coinRepository = coinRepository;
            _mapper = mapper;
        }

        public Task<QueryResponse<List<SimpleCoinsViewModel>>> Handle(GetAllCoinsQuery request, CancellationToken cancellationToken)
        {
            QueryResponse<List<SimpleCoinsViewModel>> response;
            try
            {
                var coins =  _coinRepository.Filter(x=>x.IsActive);
                var result = _mapper.Map<List<SimpleCoinsViewModel>>(coins);
                var totalCount = result.Count; 
                response = new QueryResponse<List<SimpleCoinsViewModel>>(result, totalCount);
            }
            catch (Exception e)
            {
                var errors = new List<string> { e.Message };
                if (e.InnerException != null)
                    errors.Add(e.InnerException.Message);


                response = new
                    QueryResponse<List<SimpleCoinsViewModel>>(null, 0)
                    {
                        ErrorMessage = ExceptionHandler.GetError(e)
                    };
            }

            return Task.FromResult(response) ;

        }
    }
}
