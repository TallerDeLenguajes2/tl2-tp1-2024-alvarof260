using tp1.pedido;

namespace tp1.cadete
{
    class Cadete
    {
        public string Id;
        public string Nombre;
        public string Direccion;
        public string Telefono;
        public List<Pedido> Pedidos;
        private Random random = new Random();

        public Cadete(string nombre, string direccion, string telefono)
        {
            Id = GenerarId();
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Pedidos = new List<Pedido>();
        }

        public string GenerarId()
        {
            return random.Next(0, 10000).ToString();
        }
        public int JornalACobrar()
        {
            return Pedidos.Count(p => p.Estado == true) * 500;
        }
    }
}
