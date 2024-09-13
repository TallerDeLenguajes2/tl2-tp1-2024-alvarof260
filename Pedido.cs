namespace tp1
{
    public class Pedido
    {
        public string Numero { get; private set; }
        public string Observaciones { get; private set; }
        public Cliente Cliente { get; private set; }
        private bool Estado { get; set; }
        private static Random random = new Random();
        private static HashSet<string> idGenerados = new HashSet<string>();

        public Pedido(string nombre, string direccion, string telefono, string referencia, string observaciones = "")
        {
            this.Numero = GenerarNumero();
            this.Cliente = new Cliente(nombre, direccion, telefono, referencia);
            this.Estado = false;
            this.Observaciones = observaciones;
        }

        private string GenerarNumero()
        {
            string numeroId;
            do
            {
                numeroId = random.Next(1000, 10000).ToString();
            } while (idGenerados.Contains(numeroId));
            idGenerados.Add(numeroId);
            return numeroId;
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

        public static void CambiarEstadoDePedido(Cadeteria cadeteria, string numPedido, string numCadete)
        {
            Cadete cadete = cadeteria.ObtenerCadetes().Find(c => c.Id == numCadete);
            if (cadete == null)
            {
                Console.WriteLine("Cadete no encontrado.");
                return;
            }

            Pedido pedido = cadete.ObtenerPedidos().Find(p => p.Numero == numPedido);
            if (pedido != null)
            {
                pedido.CambiarEstado(true);
                Console.WriteLine("Estado del pedido actualizado.");
            }
            else
            {
                Console.WriteLine("Pedido no encontrado.");
            }

        }

        public static void MostrarPedido(Pedido pedido)
        {
            Console.WriteLine("/-------------\\");
            Console.WriteLine("Numero de pedido: " + pedido.Numero);
            Console.WriteLine("Nombre de cliente del pedido: " + pedido.Cliente.Nombre);
            Console.WriteLine("Observacion del pedido: " + (pedido.Observaciones == "" ? "no observacion" : pedido.Observaciones));
            Console.WriteLine("\\-------------/");
        }
    }
}
