using System;
using System.Collections.Generic;
using System.Linq;

namespace MayaBinance.Domain
{
    public class GetGeneralResponse<T>
    {
        public T Result { get; set; }
        public string ErrorMessage { get; }
        public bool HasError { get; }
        public DateTime TimeGenerated { get; }

        public int TotalCount { get; set; }
        public GetGeneralResponse(T result,int totalCount,bool hasError, string errorMessage)
        {
            Result = result;
            TimeGenerated = DateTime.UtcNow;
            ErrorMessage = errorMessage;
            HasError = hasError;
            TotalCount = totalCount;
        }
    }
   
}
