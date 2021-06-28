using System;
using System.Collections.Generic;
using System.Text;

namespace mercadoeletronico.backendchallenge.DominioPedido.DTOs
{
    public class PedidoDTO
    {
        public string pedido { get; set; }
        public List<ItemPedidoDto> itens { get; set; }
    }

    public class ItemPedidoDto
    {
        public string descricao { get; set; }
        public decimal precoUnitario { get; set; }
        public int qtd { get; set; }
    }
}
