using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MayaBinance.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MayaBinance.Api
{
    public class BaseController: ControllerBase
    {

        public IActionResult GenerateResponse<TType>(QueryResponse<TType> result)
        {
            if (result.HasError)
                return BadRequest(result);
            return Ok(result);
        }
        public IActionResult GenerateResponse<TType>(Task<QueryResponse<TType>> result)
        {
            if (result.Result.HasError)
                return BadRequest(result);
            return Ok(result);
        }
        public IActionResult GenerateResponse(Result<CommandResponse> result)
        {
            
            if (result.IsSuccess)
                return Ok();
            return BadRequest(result.Value);
        }
  
    }
}
