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
                        cadetes = cadeteria.ObtenerCadetes();
                        foreach (var item in cadetes)
                        {
                            Console.WriteLine(item.Id);
                        }
                        Console.WriteLine("Ingrese el numero de Cadete");
                        numCadete = Console.ReadLine();
                        cadete = cadetes.Find(x => x.Id == numCadete);
                        foreach (var item in cadete.ObtenerPedidos())
                        {
                            Console.WriteLine(item.Numero);
                        }
                        Console.WriteLine("ingrese eL Numero de pedido");
                        numPedido = Console.ReadLine();
                        foreach (var item in cadete.ObtenerPedidos())
                        {
                            if (item.Numero == numPedido)
                            {
                                pedido = item;
                            }
                        }
                        cadetes[random.Next(0, cadetes.Count)].AsignarPedido(pedido);
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
