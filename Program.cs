namespace tp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cadeteria cadeteria = Archivos.ObtenerElPrimero("cadeteria.csv");
            List<Cadete> lista = Archivos.ListaDeCadetes("cadetes.csv");

            foreach (var item in lista)
            {
                cadeteria.AgregarCadete(item);
            }

            Console.WriteLine("Datos Cargados!");

            int op = 0;
            Pedido pedido = null;
            List<Cadete> cadetes = null;
            Cadete cadete = null;
            Random random = new Random();
            List<Pedido> pedidos = null;

            do
            {
                Menu(new string[] { "Dar de alta un pedido", "Asignar un pedido a un cadete",
                    "Cambiar el estado de un pedido", "Reasignar un pedido a otro cadete", "Salir" });
                int.TryParse(Console.ReadLine(), out op);

                switch (op)
                {
                    case 1:
                        pedido = PedidoService.DarDeAltaPedido();
                        Console.Clear();
                        PedidoService.MostrarPedido(pedido);
                        break;
                    case 2:
                        cadete = CadeteService.AsignarPedido(cadeteria, pedido, random);
                        Console.WriteLine($"Pedido asignado a cadete: {cadete.Id}");
                        pedido = null;
                        break;
                    case 3:
                        cadetes = cadeteria.ObtenerCadetes();
                        foreach (var cadeten in cadetes)
                        {
                            Console.WriteLine(cadeten.Id);
                            Console.WriteLine("--------");
                            pedidos = cadeten.ObtenerPedidos();
                            foreach (var pedidon in pedidos)
                            {
                                Console.WriteLine(pedidon.Numero);
                                Console.WriteLine("--------");
                            }
                        }

                        Console.WriteLine("Ingrese el numero de cadete: ");
                        string numCadete = Console.ReadLine();
                        Console.WriteLine("Ingrese el numero de pedido:");
                        string numPedido = Console.ReadLine();
                        PedidoService.CambiarEstadoDePedido(cadeteria, numPedido, numCadete);
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el numero de cadete: ");
                        numCadete = Console.ReadLine();
                        Console.WriteLine("Ingrese el numero de pedido:");
                        numPedido = Console.ReadLine();
                        cadete = CadeteService.ReasignarPedido(cadeteria, numCadete, numPedido, random);
                        Console.WriteLine($"Pedido asignado a cadete: {cadete.Id}");
                        pedido = null;
                        break;
                    default:
                        break;
                }
            } while (op != 5);
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
