using mercadoeletronico.backendchallenge.DominioPedido.DTOs;
using mercadoeletronico.backendchallenge.DominioPedido.Entidades;
using mercadoeletronico.backendchallenge.DominioPedido.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace mercadoeletronico.backendchallenge.DominioPedido.Interfaces
{
    public interface IPedidoService
    {
        StatusRetornoPedidoEnum NovoPedido(PedidoDTO novoPedido);
        Pedido BuscarPedidoPorId(string idPedido);
        bool ExistePedido(string idPedido);
        RetornoStatusDTO AtualizarStatus(StatusDTO status);
    }
}
