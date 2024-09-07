namespace tp1
{
    public class Cadete
    {
        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public string Direccion { get; private set; }
        public string Telefono { get; private set; }
        private List<Pedido> Pedidos { get; set; }

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
            return Guid.NewGuid().ToString();
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
}
