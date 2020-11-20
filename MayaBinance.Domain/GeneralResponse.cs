using System;

namespace MayaBinance.Domain
{
    public interface IResponse
    {
         string ErrorMessage { get; set; }
         bool HasError { get;  }
    }
    public class QueryResponse<T>:IResponse
    {
        public T Data { get; set; }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
        public DateTime TimeGenerated { get; }

        public int TotalCount { get; set; }
        public QueryResponse(T data,int totalCount)
        {
            Data = data;
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
