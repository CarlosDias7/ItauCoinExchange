using Itau.CoinExchange.Application.Contracts.Dtos.Segments;
using Itau.CoinExchange.Application.Contracts.UseCases.Segments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Api.Controllers.v1
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class SegmentController : ControllerBase
    {
        /// <summary>
        /// Retorna os segmentos para consulta de conversão de moedas.
        /// </summary>
        /// <response code="200">A consulta foi realizada com sucesso.</response>
        /// <response code="400">Ocorreu um erro inesperado durante a consulta.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SegmentDto>), 200)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSegments(CancellationToken cancellationToken, [FromServices] IGetSegmentsUseCase getSegmentsUseCase)
        {
            return Ok(await getSegmentsUseCase.ExecuteAsync(cancellationToken));
        }
    }
}
