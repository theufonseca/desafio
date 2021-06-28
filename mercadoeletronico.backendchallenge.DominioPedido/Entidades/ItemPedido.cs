using mercadoeletronico.backendchallenge.DominioPedido.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mercadoeletronico.backendchallenge.DominioPedido.Entidades
{
    public class ItemPedido
    {
        
        public ItemPedido(ItemPedidoDto itemPedidoDto)
        {
            this.Descricao = itemPedidoDto.descricao;
            this.PrecoUnitario = itemPedidoDto.precoUnitario;
            this.Quantidade = itemPedidoDto.qtd;
        }

        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
