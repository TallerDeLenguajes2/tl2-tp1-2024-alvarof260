using tp1.cliente;

namespace tp1.pedido
{
    public class Pedido
    {
        private string Numero;
        private string Observaciones;
        private Cliente Cliente;
        public bool Estado;

        private Random random = new Random();

        public Pedido(string observaciones, string nombre, string direccion, string telefono, string referencia)
        {
            Numero = GenerarNumero();
            Observaciones = observaciones;
            Cliente = new Cliente()
            {
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                DatosReferenciaDireccion = referencia
            };
            Estado = false;
        }

        private string GenerarNumero()
        {
            return random.Next(0, 10000).ToString();
        }

        public void VerDireccionCliente()
        {
            Console.WriteLine($"La direccion del cliente es: {Cliente.Direccion}");
        }

        public void VerDatosCliente()
        {
            Console.WriteLine($"El cliente es: {Cliente.Nombre}");
            Console.WriteLine($"La direccion del cliente es: {Cliente.Direccion}");
            Console.WriteLine($"El telefono del cliente es: {Cliente.Telefono}");
            Console.WriteLine($"La referencia de la direccion del cliente es: {Cliente.DatosReferenciaDireccion}");
        }

    }
}

