using System;
using System.Collections.Generic;
using System.Text;

namespace mercadoeletronico.backendchallenge.DominioPedido.DTOs
{
    public class StatusDTO
    {
        public string status { get; set; }
        public int itensAprovados { get; set; }
        public decimal valorAprovado { get; set; }
        public string pedido { get; set; }
    }
}
