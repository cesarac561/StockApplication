using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stock.Application.CasosUso.AdministrarProductos.ConsultarProductos;
using Stock.Application.CasosUso.AdministrarProductos.RegistrarProductos;

namespace Stock.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configInfo;
        public ProductosController(IMediator mediator, IConfiguration configInfo)
        {
            _mediator = mediator;
            _configInfo = configInfo;
        }

        [HttpGet("consultar")]
        public async Task<IActionResult> Consultar([FromQuery] ConsultarProductosRequest request)
        {
            //var dado1 = _configInfo["dbStocks-cnx"];
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarProductosRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("reservar")]
        public async Task<IActionResult> Reservar([FromBody] ReservarStockRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("reponer")]
        public async Task<IActionResult> Reponer([FromBody] ReponerStockRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
