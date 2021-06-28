using mercadoeletronico.backendchallenge.Infraestrutura.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace mercadoeletronico.backendchallenge.Infraestrutura.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {

        }

        public DbSet<PedidoEntity> Pedidos { get; set; }
        public DbSet<ItemEntity> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemEntity>()
                .HasOne(i => i.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(p => p.PedidoId);

            modelBuilder.Entity<PedidoEntity>()
                .HasMany(x => x.Itens)
                .WithOne(x => x.Pedido)
                .HasForeignKey(x => x.PedidoId);
        }
    }
}
