using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mercadoeletronico.backendchallenge.Infraestrutura.Entidades
{
    public class PedidoEntity
    {
        [Key]
        public string Id { get; set; }

        public List<ItemEntity> Itens { get; set; }
    }
}
