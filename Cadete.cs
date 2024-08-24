using tp1.pedido;

namespace tp1.cadete
{
    class Cadete
    {
        private string Id;
        private string Nombre;
        private string Direccion;
        private string Telefono;
        private List<Pedido> Pedidos;

        public Cadete(string id, string nombre, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Pedidos = new List<Pedido>();
        }

        public int JornalACobrar()
        {
            return Pedidos.Count(p => p.Estado == true) * 500;
        }
    }
}
