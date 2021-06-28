using mercadoeletronico.backendchallenge.DominioPedido.DTOs;
using mercadoeletronico.backendchallenge.DominioPedido.Entidades;
using mercadoeletronico.backendchallenge.DominioPedido.Interfaces;
using mercadoeletronico.backendchallenge.Infraestrutura.Data;
using mercadoeletronico.backendchallenge.Infraestrutura.Entidades;
using mercadoeletronico.backendchallenge.Infraestrutura.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mercadoeletronico.backendchallenge.Infraestrutura.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly Contexto contexto;

        public PedidoRepositorio(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public void InserirPedido(Pedido pedido)
        {
            var pedidoEntity = new PedidoEntity();
            pedidoEntity.Itens = new List<ItemEntity>();

            pedidoEntity.Id = pedido.pedido;

            foreach (var item in pedido.Itens)
                pedidoEntity.Itens.Add(new ItemEntity
                {
                    Descricao = item.Descricao,
                    PrecoUnitario = item.PrecoUnitario,
                    Quantidade = item.Quantidade,
                    PedidoId = pedidoEntity.Id
                });

            contexto.Pedidos.Add(pedidoEntity);
            contexto.SaveChangesAsync();
        }

        public Pedido BuscarPedidoPorId(string id)
        {
            var pedidoEntity = contexto.Pedidos
                                       .Where(x => x.Id == id)
                                       .Include(x => x.Itens).FirstOrDefault();

            if (pedidoEntity == null)
                return null;

            var pedido = pedidoEntity.PedidoEntityParaPedido();

            return pedido;
        }
    }
}
