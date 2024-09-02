namespace tp1
{
    public class Cadete
    {
        private string Id { get; set; }
        private string Nombre { get; set; }
        private string Direccion { get; set; }
        private string Telefono { get; set; }
        private List<Pedido> Pedidos { get; set; }
        private Random random = new Random();

        public Cadete(string Nombre, string Direccion, string Telefono, List<Pedido> Pedidos)
        {
            Id = GenerarId();
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Pedidos = Pedidos;
        }

        public string GenerarId()
        {
            return random.Next(0, 10000).ToString();
        }
    }
}
