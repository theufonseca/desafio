using mercadoeletronico.backendchallenge.DominioPedido.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace mercadoeletronico.backendchallenge.DominioPedido.ObjetosDeValor
{
    public class StatusPedido
    {
        public StatusRetornoPedidoEnum StatusRetornoPedido { get; set; }
        public string MensagemRetornoPedido
        {
            get
            {
                return StatusPedido.BuscarMensagemRetorno(StatusRetornoPedido);
            }
        }

        public static string BuscarMensagemRetorno(StatusRetornoPedidoEnum StatusRetornoPedido)
        {
            switch (StatusRetornoPedido)
            {
                case StatusRetornoPedidoEnum.Aprovado:
                    return "APROVADO";
                case StatusRetornoPedidoEnum.CodigoPedidoInvalido:
                    return "CODIGO_PEDIDO_INVALIDO";
                case StatusRetornoPedidoEnum.Reprovado:
                    return "REPROVADO";
                case StatusRetornoPedidoEnum.AprovadoValorAMenor:
                    return "APROVADO_VALOR_A_MENOR";
                case StatusRetornoPedidoEnum.AprovadoQuantidadeMenor:
                    return "APROVADO_QTD_A_MENOR";
                case StatusRetornoPedidoEnum.AprovadoValorAMaior:
                    return "APROVADO_VALOR_A_MAIOR";
                case StatusRetornoPedidoEnum.AprovadoQuantidadeAMaior:
                    return "APROVADO_QTD_A_MAIOR";
                case StatusRetornoPedidoEnum.DescricaoDoItemInvalida:
                    return "DESCRICAO_ITEM_INVALIDO";
                case StatusRetornoPedidoEnum.PrecoUnitarioDoItemPrecisaSerMaiorQueZero:
                    return "PRECO_ITEM_MENOR_IGUAL_ZERO";
                case StatusRetornoPedidoEnum.QuantidadeDoItemPrecisaSerMaiorQueZero:
                    return "QUANTIDADE_ITEM_MENOR_IGUAL_ZERO";
                case StatusRetornoPedidoEnum.PedidoInseridoComSucesso:
                    return "PEDIDO_INSERIDO_COM_SUCESSO";
                case StatusRetornoPedidoEnum.ErroAoInserirPedido:
                    return "ERRO_INSERIR_PEDIDO";
                case StatusRetornoPedidoEnum.PedidoJaExiste:
                    return "JA_EXISTE_PEDIDO_COM_ESSE_ID";
                case StatusRetornoPedidoEnum.ErroAoAtualizarStatus:
                    return "ERRO_AO_ATUALIZAR_STATUS";
                default:
                    return "ERRO_INESPERADO";
            }
        }
    }
}
