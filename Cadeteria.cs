namespace tp1
{
    public class Cadeteria
    {
        public string Nombre { get; private set; }
        public string Telefono { get; private set; }
        private List<Cadete> Cadetes { get; set; }
        private List<Pedido> Pedidos { get; set; }

        public Cadeteria(string nombre, string telefono, List<Cadete> cadetes = null, List<Pedido> pedidos = null)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Cadetes = cadetes ?? new List<Cadete>();
            this.Pedidos = pedidos ?? new List<Pedido>();
        }

        public void AgregarCadete(Cadete cadete)
        {
            this.Cadetes.Add(cadete);
        }

        public List<Cadete> ObtenerCadetes()
        {
            return this.Cadetes;
        }

        public void AgregarPedido(Pedido pedido)
        {
            this.Pedidos.Add(pedido);
        }

        public List<Pedido> ObtenerPedidos()
        {
            return this.Pedidos;
        }

        public double JornalACobrar(string idCadete)
        {
            Cadete cadete = Cadetes.Find(c => c.Id == idCadete);
            if (cadete != null)
            {
                return Pedidos.Where(p => p.CadeteAsignado?.Id == idCadete).Count() * 500;
            }
            return 0;
        }

        public void AsignarCadeteAPedido(string idCadete, string idPedido)
        {
            Cadete cadete = Cadetes.Find(c => c.Id == idCadete);
            Pedido pedido = Pedidos.Find(p => p.Numero == idPedido);

            if (cadete != null && pedido != null)
            {
                pedido.AsignarCadete(cadete);
                Console.WriteLine($"Pedido {idPedido} asignado al cadete {cadete.Nombre}.");
            }
            else
            {
                Console.WriteLine("Error al asignar el pedido.");
            }
        }

    }
}
