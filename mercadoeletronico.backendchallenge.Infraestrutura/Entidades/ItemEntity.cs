using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mercadoeletronico.backendchallenge.Infraestrutura.Entidades
{
    public class ItemEntity
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Descricao { get; set; }

        [Required]
        public decimal PrecoUnitario { get; set; }

        [Required]
        public int Quantidade { get; set; }


        [Required]
        public string PedidoId { get; set; }
        public PedidoEntity Pedido { get; set; }
    }
}
