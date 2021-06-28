using mercadoeletronico.backendchallenge.DominioPedido.DTOs;
using mercadoeletronico.backendchallenge.DominioPedido.Entidades;
using mercadoeletronico.backendchallenge.Infraestrutura.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace mercadoeletronico.backendchallenge.Infraestrutura.Helpers
{
    public static class ConversaoDeEntidades
    {
        public static Pedido PedidoEntityParaPedido(this PedidoEntity pedidoEntity)
        {
            var pedidoDto = new PedidoDTO();
            pedidoDto.itens = new List<ItemPedidoDto>();

            pedidoDto.pedido = pedidoEntity.Id.ToString();


            foreach (var item in pedidoEntity.Itens)
                pedidoDto.itens.Add(new ItemPedidoDto
                {
                    descricao = item.Descricao,
                    precoUnitario = item.PrecoUnitario,
                    qtd = item.Quantidade
                });

            var pedido = new Pedido(pedidoDto);

            return pedido;
        }
    }
}
