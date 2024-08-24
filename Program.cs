using System;
using tp1.cliente;
using tp1.pedido;

partial class Program
{
    public static void Main()
    {
        Pedido nuevo = new Pedido("Sin observaciones", "Juan", "Calle falsa 123", "123456789", "Calle falsa 123");

        nuevo.VerDireccionCliente();

        nuevo.VerDatosCliente();
    }
}
