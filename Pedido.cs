namespace tp1
{
    public class Pedido
    {
        public string Numero { get; private set; }
        public string Observaciones { get; private set; }
        public Cliente Cliente { get; private set; }
        private bool Estado { get; set; }

        public Pedido(string nombre, string direccion, string telefono, string referencia, string observaciones = "")
        {
            this.Numero = GenerarNumero();
            this.Cliente = new Cliente(nombre, direccion, telefono, referencia);
            this.Estado = false;
            this.Observaciones = observaciones;
        }

        private string GenerarNumero()
        {
            return Guid.NewGuid().ToString();
        }

        public void CambiarEstado(bool estado)
        {
            this.Estado = estado;
        }

        public bool ObtenerEstado()
        {
            return this.Estado;
        }
    }

    class PedidoService
    {
        public static Pedido DarDeAltaPedido()
        {
            Console.WriteLine("Dar de alta un pedido");
            Console.WriteLine("Escriba las observaciones del pedido");
            string observaciones = Console.ReadLine();
            Console.WriteLine("Escriba el nombre del cliente");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escriba la direccion del cliente");
            string direccion = Console.ReadLine();
            Console.WriteLine("Escriba el telefono del cliente");
            string telefono = Console.ReadLine();
            Console.WriteLine("Escriba la referencia del cliente");
            string referencia = Console.ReadLine();
            Pedido pedido = new Pedido(observaciones, nombre, direccion, telefono, referencia);

            return pedido;
        }
    }
}
