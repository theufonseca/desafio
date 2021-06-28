using System;
using System.Collections.Generic;
using System.Text;

namespace mercadoeletronico.backendchallenge.DominioPedido.DTOs
{
    public class RetornoStatusDTO
    {
        public string pedido { get; set; }
        public List<string> status { get; set; }
    }
}
