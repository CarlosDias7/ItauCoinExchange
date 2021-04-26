using Itau.CoinExchange.Api.Controllers.Base;
using Itau.CoinExchange.Application.Contracts.Dtos.Segments;
using Itau.CoinExchange.Application.Contracts.UseCases.Segments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/coins/convertions")]
    public class CoinConvertionController : BaseController
    {
        /// <summary>
        /// Realiza a cotação e compra de moedas estrangeiras por segmento.
        /// </summary>
        /// <response code="200">A contação foi realizada com sucesso.</response>
        /// <response code="400">Ocorreu um erro inesperado durante a cotação.</response>
        [HttpGet("segment")]
        [ProducesResponseType(typeof(IEnumerable<SegmentDto>), 200)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConvertCoinBySegment([FromQuery] ConvertCoinBySegmentDto dto, CancellationToken cancellationToken, [FromServices] IConvertCoinBySegmentUseCase convertCoinBySegmentUseCase)
        {
            return ApiSuccessResult(await convertCoinBySegmentUseCase.ExecuteAsync(dto, cancellationToken));
        }
    }
}