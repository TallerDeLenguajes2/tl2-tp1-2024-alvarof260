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
                cadeteria.AddCadete(item);
            }

            Console.WriteLine("Datos Cargados!");

            int op = 0;
            Pedido pedido = null;
            List<Cadete> cadetes = null;
            Cadete cadete = null;
            Random random = new Random();

            do
            {
                Console.WriteLine("1. Dar de alta un pedido");
                Console.WriteLine("2. Asignar un pedido a un cadete");
                Console.WriteLine("3. Cambiar el estado de un pedido");
                Console.WriteLine("4. Reasignar un pedido a otro cadete");
                Console.WriteLine("5. Salir");

                int.TryParse(Console.ReadLine(), out op);

                switch (op)
                {
                    case 1:
                        pedido = Pedido.DarDeAlta();
                        break;
                    case 2:
                        cadetes = cadeteria.GetCadetes();
                        cadetes[random.Next(0, cadetes.Count)].AsignarPedido(pedido);
                        Console.WriteLine("asignado");
                        pedido = null;
                        break;
                    case 3:
                        cadetes = cadeteria.GetCadetes();
                        foreach (var item in cadetes)
                        {
                            Console.WriteLine(item.GetId());
                        }
                        Console.WriteLine("Ingrese el numero de Cadete");
                        string numCadete = Console.ReadLine();
                        cadete = cadetes.Find(x => x.GetId() == numCadete);
                        foreach (var item in cadete.GetPedidos())
                        {
                            Console.WriteLine(item.GetNumero());
                        }
                        Console.WriteLine("ingrese eL Numero de pedido");
                        string numPedido = Console.ReadLine();
                        foreach (var item in cadete.GetPedidos())
                        {
                            if (item.GetNumero() == numPedido)
                            {
                                item.CambiarEstado();
                            }
                        }
                        break;
                    case 4:
                        cadetes = cadeteria.GetCadetes();
                        foreach (var item in cadetes)
                        {
                            Console.WriteLine(item.GetId());
                        }
                        Console.WriteLine("Ingrese el numero de Cadete");
                        numCadete = Console.ReadLine();
                        cadete = cadetes.Find(x => x.GetId() == numCadete);
                        foreach (var item in cadete.GetPedidos())
                        {
                            Console.WriteLine(item.GetNumero());
                        }
                        Console.WriteLine("ingrese eL Numero de pedido");
                        numPedido = Console.ReadLine();
                        foreach (var item in cadete.GetPedidos())
                        {
                            if (item.GetNumero() == numPedido)
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
    }
}
