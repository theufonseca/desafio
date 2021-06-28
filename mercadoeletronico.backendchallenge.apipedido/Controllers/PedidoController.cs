using mercadoeletronico.backendchallenge.DominioPedido.DTOs;
using mercadoeletronico.backendchallenge.DominioPedido.Entidades;
using mercadoeletronico.backendchallenge.DominioPedido.Enum;
using mercadoeletronico.backendchallenge.DominioPedido.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mercadoeletronico.backendchallenge.apipedido.Controllers
{
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        [HttpPost("pedido")]
        public IActionResult Pedido([FromBody] PedidoDTO pedido)
        {
            var statusDoPedido = pedidoService.NovoPedido(pedido);

            if (statusDoPedido == StatusRetornoPedidoEnum.PedidoInseridoComSucesso)
                return Ok();

            return BadRequest();
        }

        [HttpPut("status")]
        public IActionResult Status([FromBody] StatusDTO status)
        {

            var retornoStatus = pedidoService.AtualizarStatus(status);

            return Ok(retornoStatus);
        }
    }
}
