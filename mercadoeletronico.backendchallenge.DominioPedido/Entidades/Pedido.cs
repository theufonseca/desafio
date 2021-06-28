using mercadoeletronico.backendchallenge.DominioPedido.DTOs;
using mercadoeletronico.backendchallenge.DominioPedido.Enum;
using mercadoeletronico.backendchallenge.DominioPedido.ObjetosDeValidacao;
using mercadoeletronico.backendchallenge.DominioPedido.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace mercadoeletronico.backendchallenge.DominioPedido.Entidades
{
    public class Pedido
    {
        public Pedido()
        {
            StatusDoPedido = new List<StatusPedido>();
            Itens = new List<ItemPedido>();
        }

        public Pedido(PedidoDTO pedidoDto)
        {
            StatusDoPedido = new List<StatusPedido>();
            Itens = new List<ItemPedido>();

            pedido = pedidoDto.pedido;
            IncluirTodosItens(pedidoDto.itens);
        }

        public string pedido { get; set; }
        public List<ItemPedido> Itens { get; set; }
        public List<StatusPedido> StatusDoPedido { get; set; }

        public void IncluirTodosItens(IEnumerable<ItemPedidoDto> itensPedido)
        {
            foreach (var itemPedidoDto in itensPedido)
                IncluirItem(itemPedidoDto);
        }

        public void IncluirItem(ItemPedidoDto itemPedidoDto)
        {
            var itemPedido = new ItemPedido(itemPedidoDto);

            ValidarItemPedido(itemPedido);
            Itens.Add(itemPedido);
        }

        private void ValidarItemPedido(ItemPedido itemPedido)
        {
            var statusPedido = itemPedido.ValidarItem();

            foreach (var item in statusPedido)
                AdicionarStatusPedido(item);
        }

        private void AdicionarStatusPedido(StatusPedido novoStatus)
        {
            if (!StatusDoPedido.Exists(x => x.StatusRetornoPedido == novoStatus.StatusRetornoPedido))
                StatusDoPedido.Add(novoStatus);
        }

        public decimal CalcularValorTotalPedido()
        {
            var somaTotal = 0.0M;

            foreach (var item in Itens)
                somaTotal += item.Quantidade * item.PrecoUnitario;

            return somaTotal;
        }

        public int CalcularQuantidadeItensPedido()
        {
            var quantidadeItens = 0;

            foreach (var item in Itens)
                quantidadeItens += item.Quantidade;

            return quantidadeItens;
        }
    }
}
