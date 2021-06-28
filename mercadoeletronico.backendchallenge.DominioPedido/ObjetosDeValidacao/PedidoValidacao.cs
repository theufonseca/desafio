using mercadoeletronico.backendchallenge.DominioPedido.Entidades;
using mercadoeletronico.backendchallenge.DominioPedido.Enum;
using mercadoeletronico.backendchallenge.DominioPedido.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace mercadoeletronico.backendchallenge.DominioPedido.ObjetosDeValidacao
{
    public static class PedidoValidacao
    {
        public static List<StatusPedido> ValidarItem(this ItemPedido itemPedido)
        {
            var statusPedido = new List<StatusPedido>();

            if (string.IsNullOrEmpty(itemPedido.Descricao))
                statusPedido.Add(new StatusPedido
                {
                    StatusRetornoPedido = StatusRetornoPedidoEnum.DescricaoDoItemInvalida
                });

            if (itemPedido.PrecoUnitario <= 0)
                statusPedido.Add(new StatusPedido
                {
                    StatusRetornoPedido = StatusRetornoPedidoEnum.PrecoUnitarioDoItemPrecisaSerMaiorQueZero
                });

            if (itemPedido.Quantidade <= 0)
                statusPedido.Add(new StatusPedido
                {
                    StatusRetornoPedido = StatusRetornoPedidoEnum.QuantidadeDoItemPrecisaSerMaiorQueZero
                });

            return statusPedido;
        }
    }
}
