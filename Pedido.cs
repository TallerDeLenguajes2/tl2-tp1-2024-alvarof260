namespace tp1
{
    public class Pedido
    {
        private string Numero;
        private string Observaciones;
        private Cliente Cliente;
        private bool Estado;

        private Random random = new Random();

        public Pedido(string Observaciones, string Nombre, string Direccion, string Telefono, string Referencia)
        {
            this.Numero = GenerarNumero();
            this.Observaciones = Observaciones;
            this.Cliente = new Cliente(Nombre, Direccion, Telefono, Referencia);
            this.Estado = false;
        }

        public Pedido(string Nombre, string Direccion, string Telefono, string Referencia)
        {
            this.Numero = GenerarNumero();
            this.Observaciones = "";
            this.Cliente = new Cliente(Nombre, Direccion, Telefono, Referencia);
            this.Estado = false;
        }

        private string GenerarNumero()
        {
            return random.Next(0, 10000).ToString();
        }
    }
}

