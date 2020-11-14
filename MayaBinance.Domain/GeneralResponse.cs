using System;
using System.Collections.Generic;
using System.Linq;

namespace MayaBinance.Domain
{
    public interface IResponse
    {
         string ErrorMessage { get; set; }
         bool HasError { get;  }
    }
    public class QueryResponse<T>:IResponse
    {
        public T Result { get; set; }
        public bool HasError => string.IsNullOrEmpty(ErrorMessage);
        public DateTime TimeGenerated { get; }

        public int TotalCount { get; set; }
        public QueryResponse(T result,int totalCount)
        {
            Result = result;
            TimeGenerated = DateTime.UtcNow;
            TotalCount = totalCount;
        }

        public string ErrorMessage { get; set; }
    }

    public class CommandResponse: IResponse
    {
        
        public string ErrorMessage { get; set; }
        public bool HasError => string.IsNullOrEmpty(ErrorMessage);
    }
   
}
