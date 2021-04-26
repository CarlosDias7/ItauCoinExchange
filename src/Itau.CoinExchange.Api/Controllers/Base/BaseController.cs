using Itau.CoinExchange.Api.RequestResults;
using Microsoft.AspNetCore.Mvc;

namespace Itau.CoinExchange.Api.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ApiSuccessResult<TData>(TData data)
            where TData : class
        {
            var requestResult = new RequestResult<TData>
            {
                Success = true,
                Data = data
            };

            return Ok(requestResult);
        }
    }
}