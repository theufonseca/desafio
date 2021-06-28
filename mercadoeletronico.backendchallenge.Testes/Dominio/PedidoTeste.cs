using mercadoeletronico.backendchallenge.DominioPedido.DTOs;
using mercadoeletronico.backendchallenge.DominioPedido.Entidades;
using mercadoeletronico.backendchallenge.DominioPedido.Interfaces;
using mercadoeletronico.backendchallenge.DominioPedido.Servicos;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace mercadoeletronico.backendchallenge.Testes.Dominio
{
    public class PedidoTeste
    {
        private Mock<IPedidoRepositorio> GerarMockPedidoRepositorio()
        {
            //Arranjo
            Mock<IPedidoRepositorio> mock = new Mock<IPedidoRepositorio>();
            mock.Setup(x => x.BuscarPedidoPorId(It.IsAny<string>()))
                .Returns((new Pedido(new DominioPedido.DTOs.PedidoDTO()
                {
                    pedido = "123456",
                    itens = new List<ItemPedidoDto>()
                    {
                        new ItemPedidoDto
                        {
                            descricao = "Item A",
                            precoUnitario = 10.0M,
                            qtd = 1
                        },
                        new ItemPedidoDto
                        {
                            descricao = "Item B",
                            precoUnitario = 5.0M,
                            qtd = 2
                        }
                    }
                })));

            return mock;
        }

        [Fact]
        public void AtualizarStatus_DeveRetornarAprovado()
        {
            //Arranjo
            var mock = GerarMockPedidoRepositorio();

            var statusEntradaDto = new StatusDTO
            {
                status = "APROVADO",
                itensAprovados = 3,
                valorAprovado = 20,
                pedido = "123456"
            };

            var statusEsperados = new RetornoStatusDTO
            {
                pedido = "123456",
                status = new List<string>() { "APROVADO" }
            };

            var pedidoService = new PedidoService(mock.Object);
            
            //Ação
            var retornoStatus = pedidoService.AtualizarStatus(statusEntradaDto);

            //Validação
            var statusEsperadosJson = JsonConvert.SerializeObject(statusEsperados);
            var statusRetornoJson = JsonConvert.SerializeObject(retornoStatus);

            Assert.Equal(statusEsperadosJson, statusRetornoJson);
        }

        [Fact]
        public void AtualizarStatus_DeveRetornarAprovadoValorAMenor()
        {
            //Arranjo
            var mock = GerarMockPedidoRepositorio();

            var statusEntradaDto = new StatusDTO
            {
                status = "APROVADO",
                itensAprovados = 3,
                valorAprovado = 10,
                pedido = "123456"
            };

            var statusEsperados = new RetornoStatusDTO
            {
                pedido = "123456",
                status = new List<string>() { "APROVADO_VALOR_A_MENOR" }
            };

            var pedidoService = new PedidoService(mock.Object);

            //Ação
            var retornoStatus = pedidoService.AtualizarStatus(statusEntradaDto);

            //Validação
            var statusEsperadosJson = JsonConvert.SerializeObject(statusEsperados);
            var statusRetornoJson = JsonConvert.SerializeObject(retornoStatus);

            Assert.Equal(statusEsperadosJson, statusRetornoJson);
        }

        [Fact]
        public void AtualizarStatus_DeveRetornarAprovadoValorAMaior_E_AprovadoQtdAMaior()
        {
            //Arranjo
            var mock = GerarMockPedidoRepositorio();

            var statusEntradaDto = new StatusDTO
            {
                status = "APROVADO",
                itensAprovados = 4,
                valorAprovado = 21,
                pedido = "123456"
            };

            var statusEsperados = new RetornoStatusDTO
            {
                pedido = "123456",
                status = new List<string>() { "APROVADO_VALOR_A_MAIOR", "APROVADO_QTD_A_MAIOR" }
            };

            var pedidoService = new PedidoService(mock.Object);

            //Ação
            var retornoStatus = pedidoService.AtualizarStatus(statusEntradaDto);

            //Validação
            var statusEsperadosJson = JsonConvert.SerializeObject(statusEsperados);
            var statusRetornoJson = JsonConvert.SerializeObject(retornoStatus);

            Assert.Equal(statusEsperadosJson, statusRetornoJson);
        }

        [Fact]
        public void AtualizarStatus_DeveRetornarAprovadoQtdAMenor()
        {
            //Arranjo
            var mock = GerarMockPedidoRepositorio();

            var statusEntradaDto = new StatusDTO
            {
                status = "APROVADO",
                itensAprovados = 2,
                valorAprovado = 20,
                pedido = "123456"
            };

            var statusEsperados = new RetornoStatusDTO
            {
                pedido = "123456",
                status = new List<string>() { "APROVADO_QTD_A_MENOR" }
            };

            var pedidoService = new PedidoService(mock.Object);

            //Ação
            var retornoStatus = pedidoService.AtualizarStatus(statusEntradaDto);

            //Validação
            var statusEsperadosJson = JsonConvert.SerializeObject(statusEsperados);
            var statusRetornoJson = JsonConvert.SerializeObject(retornoStatus);

            Assert.Equal(statusEsperadosJson, statusRetornoJson);
        }

        [Fact]
        public void AtualizarStatus_DeveRetornarReprovado()
        {
            //Arranjo
            var mock = GerarMockPedidoRepositorio();

            var statusEntradaDto = new StatusDTO
            {
                status = "REPROVADO",
                itensAprovados = 0,
                valorAprovado = 0,
                pedido = "123456"
            };

            var statusEsperados = new RetornoStatusDTO
            {
                pedido = "123456",
                status = new List<string>() { "REPROVADO" }
            };

            var pedidoService = new PedidoService(mock.Object);

            //Ação
            var retornoStatus = pedidoService.AtualizarStatus(statusEntradaDto);

            //Validação
            var statusEsperadosJson = JsonConvert.SerializeObject(statusEsperados);
            var statusRetornoJson = JsonConvert.SerializeObject(retornoStatus);

            Assert.Equal(statusEsperadosJson, statusRetornoJson);
        }

        [Fact]
        public void AtualizarStatus_DeveRetornarCodigoPedidoInvalido()
        {
            //Arranjo
            Mock<IPedidoRepositorio> mock = new Mock<IPedidoRepositorio>();
            mock.Setup(x => x.BuscarPedidoPorId(It.IsAny<string>()))
                .Returns((Pedido)null);

            var statusEntradaDto = new StatusDTO
            {
                status = "APROVADO",
                itensAprovados = 3,
                valorAprovado = 20,
                pedido = "123456-N"
            };

            var statusEsperados = new RetornoStatusDTO
            {
                pedido = "123456-N",
                status = new List<string>() { "CODIGO_PEDIDO_INVALIDO" }
            };

            var pedidoService = new PedidoService(mock.Object);

            //Ação
            var retornoStatus = pedidoService.AtualizarStatus(statusEntradaDto);

            //Validação
            var statusEsperadosJson = JsonConvert.SerializeObject(statusEsperados);
            var statusRetornoJson = JsonConvert.SerializeObject(retornoStatus);

            Assert.Equal(statusEsperadosJson, statusRetornoJson);
        }
    }
}
