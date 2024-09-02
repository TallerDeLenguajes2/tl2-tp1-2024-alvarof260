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

        public static Pedido DarDeAlta()
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

        public string GetNumero()
        {
            return this.Numero;
        }

        public void CambiarEstado()
        {
            this.Estado = true;
        }
    }
}

