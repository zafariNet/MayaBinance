using System;
using CSharpFunctionalExtensions;
using MayaBinance.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MayaBinance.Api
{
    public class BaseController: ControllerBase
    {

        public IActionResult GeneralResponse<TType>(GetGeneralResponse<TType> result)
        {
            if (result.HasError)
                return BadRequest(result);

            return Ok(result);
        }
    
  
    }
}
