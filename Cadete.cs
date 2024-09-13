namespace tp1
{
    public class Cadete
    {
        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public string Direccion { get; private set; }
        public string Telefono { get; private set; }
        private List<Pedido> Pedidos { get; set; }
        private static Random random = new Random();
        private static HashSet<string> idGenerados = new HashSet<string>();

        public Cadete(string nombre, string direccion, string telefono, List<Pedido> pedidos = null)
        {
            Id = GenerarId();
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Pedidos = pedidos ?? new List<Pedido>();
        }

        public string GenerarId()
        {
            string numeroId;
            do
            {
                numeroId = random.Next(1000, 10000).ToString();
            } while (idGenerados.Contains(numeroId));
            idGenerados.Add(numeroId);
            return numeroId;
        }

        public void AsignarPedido(Pedido pedido)
        {
            this.Pedidos.Add(pedido);
        }

        public List<Pedido> ObtenerPedidos()
        {
            return this.Pedidos;
        }
    }

    public class CadeteService
    {
        public static Cadete AsignarPedido(Cadeteria cadeteria, Pedido pedido, Random random)
        {
            if (pedido == null)
            {
                Console.WriteLine("No hay pedido para asignar.");
                return null;
            }

            List<Cadete> cadetes = cadeteria.ObtenerCadetes();

            if (cadetes.Count == 0)
            {
                Console.WriteLine("No hay cadetes para asignar el pedido.");
                return null;
            }

            Cadete seleccionado = cadetes[random.Next(0, cadetes.Count)];

            cadeteria.ObtenerCadetes().Find(c => c.Id == seleccionado.Id)?.AsignarPedido(pedido);

            return seleccionado;
        }
        public static Cadete ReasignarPedido(Cadeteria cadeteria, string numCadete, string numPedido, Random random)
        {
            Cadete cadete = cadeteria.ObtenerCadetes().Find(c => c.Id == numCadete);
            if (cadete == null)
            {
                Console.WriteLine("Cadete no encontrado.");
                return null;
            }

            Pedido pedido = cadete.ObtenerPedidos().Find(p => p.Numero == numPedido);
            if (pedido == null)
            {
                Console.WriteLine("Pedido no encontrado.");
                return null;
            }

            List<Cadete> cadetes = cadeteria.ObtenerCadetes();
            Cadete seleccionado;
            do
            {
                seleccionado = cadetes[random.Next(0, cadetes.Count)];
            } while (seleccionado == cadete);
            cadeteria.ObtenerCadetes().Find(c => c.Id == seleccionado.Id)?.AsignarPedido(pedido);
            return seleccionado;
        }
    }
}
