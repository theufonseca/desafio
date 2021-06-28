using System;
using System.Collections.Generic;
using System.Text;

namespace mercadoeletronico.backendchallenge.DominioPedido.Enum
{
    public enum StatusRetornoPedidoEnum
    {
        Aprovado = 1,
        CodigoPedidoInvalido = 2,
        Reprovado = 3,
        AprovadoValorAMenor = 4,
        AprovadoQuantidadeMenor = 5,
        AprovadoValorAMaior = 6,
        AprovadoQuantidadeAMaior = 7,
        DescricaoDoItemInvalida = 8,
        PrecoUnitarioDoItemPrecisaSerMaiorQueZero = 9,
        QuantidadeDoItemPrecisaSerMaiorQueZero = 10,
        PedidoInseridoComSucesso = 11,
        ErroAoInserirPedido = 12,
        PedidoJaExiste = 13,
        ErroAoAtualizarStatus = 14
    }
}
