using mercadoeletronico.backendchallenge.DominioPedido.Entidades;

namespace mercadoeletronico.backendchallenge.DominioPedido.Interfaces
{
    public interface IPedidoRepositorio
    {
        void InserirPedido(Pedido pedido);
        Pedido BuscarPedidoPorId(string id);
    }
}
