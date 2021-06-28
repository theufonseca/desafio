using mercadoeletronico.backendchallenge.DominioPedido.DTOs;
using mercadoeletronico.backendchallenge.DominioPedido.Entidades;
using mercadoeletronico.backendchallenge.DominioPedido.Enum;
using mercadoeletronico.backendchallenge.DominioPedido.Interfaces;
using mercadoeletronico.backendchallenge.DominioPedido.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercadoeletronico.backendchallenge.DominioPedido.Servicos
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio pedidoRepository;

        public PedidoService(IPedidoRepositorio pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public RetornoStatusDTO AtualizarStatus(StatusDTO statusDto)
        {
            try
            {
                var retornoStatus = new RetornoStatusDTO()
                {
                    pedido = statusDto.pedido,
                    status = new List<string>()
                };

                var pedido = BuscarPedidoPorId(statusDto.pedido);

                if (pedido == null)
                {
                    retornoStatus.status.Add(StatusPedido.BuscarMensagemRetorno(StatusRetornoPedidoEnum.CodigoPedidoInvalido));
                    return retornoStatus;
                }

                if (statusDto.status == "REPROVADO")
                {
                    retornoStatus.status.Add(StatusPedido.BuscarMensagemRetorno(StatusRetornoPedidoEnum.Reprovado));
                    return retornoStatus;
                }

                if (statusDto.valorAprovado < pedido.CalcularValorTotalPedido())
                    retornoStatus.status.Add(StatusPedido.BuscarMensagemRetorno(StatusRetornoPedidoEnum.AprovadoValorAMenor));

                if (statusDto.valorAprovado > pedido.CalcularValorTotalPedido())
                    retornoStatus.status.Add(StatusPedido.BuscarMensagemRetorno(StatusRetornoPedidoEnum.AprovadoValorAMaior));

                if (statusDto.itensAprovados < pedido.CalcularQuantidadeItensPedido())
                    retornoStatus.status.Add(StatusPedido.BuscarMensagemRetorno(StatusRetornoPedidoEnum.AprovadoQuantidadeMenor));

                if (statusDto.itensAprovados > pedido.CalcularQuantidadeItensPedido())
                    retornoStatus.status.Add(StatusPedido.BuscarMensagemRetorno(StatusRetornoPedidoEnum.AprovadoQuantidadeAMaior));

                if (retornoStatus.status.Count() == 0)
                    retornoStatus.status.Add(StatusPedido.BuscarMensagemRetorno(StatusRetornoPedidoEnum.Aprovado));

                return retornoStatus;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public Pedido BuscarPedidoPorId(string idPedido)
        {
            var pedido = pedidoRepository.BuscarPedidoPorId(idPedido);

            return pedido;
        }

        public bool ExistePedido(string idPedido)
        {
            var pedido = BuscarPedidoPorId(idPedido);

            return pedido != null;
        }

        public StatusRetornoPedidoEnum NovoPedido(PedidoDTO novoPedidoDto)
        {
            try
            {
                if (ExistePedido(novoPedidoDto.pedido))
                    return StatusRetornoPedidoEnum.PedidoJaExiste;

                var novoPedido = new Pedido(novoPedidoDto);

                if (novoPedido.StatusDoPedido.Count() == 0)
                    pedidoRepository.InserirPedido(novoPedido);

                return StatusRetornoPedidoEnum.PedidoInseridoComSucesso;
            }
            catch (Exception ex)
            {
                return StatusRetornoPedidoEnum.ErroAoInserirPedido;
            }
        }
    }
}
