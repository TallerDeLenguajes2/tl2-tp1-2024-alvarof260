namespace tp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AccesoADatos accesoDatos = null;

            Console.WriteLine("Seleccione el tipo de acceso a datos:");
            Console.WriteLine("1. CSV");
            Console.WriteLine("2. JSON");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                accesoDatos = new AccesoCSV();
            }
            else if (opcion == 2)
            {
                accesoDatos = new AccesoJSON();
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                return;
            }

            string rutaCadetes = opcion == 1 ? "cadetes.csv" : "cadetes.json";
            string rutaPedidos = opcion == 1 ? "pedidos.csv" : "pedidos.json";

            List<Cadete> cadetes = accesoDatos.CargarCadetes(rutaCadetes);
            List<Pedido> pedidos = accesoDatos.CargarPedidos(rutaPedidos);


            int op = 0;
            Pedido pedido = null;
            Random random = new Random();
            List<Cadete> cadetes = null;

            do
            {
                Menu(new string[] { "Dar de alta un pedido", "Asignar un pedido a un cadete",
                "Jornal a cobrar por cadete", "Salir" });
                int.TryParse(Console.ReadLine(), out op);

                switch (op)
                {
                    case 1:
                        pedido = PedidoService.DarDeAltaPedido();
                        cadeteria.AgregarPedido(pedido);
                        Console.WriteLine(pedido.Numero);
                        break;

                    case 2:
                        cadetes = cadeteria.ObtenerCadetes();
                        Console.WriteLine("Cadetes");
                        foreach (var cadete in cadetes)
                        {
                            Console.WriteLine(cadete.Id);
                            Console.WriteLine("----------");
                        }
                        Console.WriteLine("Ingrese el ID del cadete:");
                        string idCadete = Console.ReadLine();
                        Console.WriteLine("Ingrese el número de pedido:");
                        string numPedido = Console.ReadLine();
                        cadeteria.AsignarCadeteAPedido(idCadete, numPedido);
                        break;

                    case 3:
                        cadetes = cadeteria.ObtenerCadetes();
                        Console.WriteLine("Cadetes");
                        foreach (var cadete in cadetes)
                        {
                            Console.WriteLine(cadete.Id);
                            Console.WriteLine("----------");
                        }
                        Console.WriteLine("Ingrese el ID del cadete:");
                        idCadete = Console.ReadLine();
                        double jornal = cadeteria.JornalACobrar(idCadete);
                        Console.WriteLine($"El jornal a cobrar es: {jornal}");
                        break;
                }
            } while (op != 4);
        }

        public static void Menu(string[] opciones)
        {
            for (int i = 0; i < opciones.Count(); i++)
            {
                Console.WriteLine($"{i + 1} - {opciones[i]}");
            }
        }
    }
}
