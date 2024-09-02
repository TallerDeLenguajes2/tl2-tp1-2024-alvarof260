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
                        List<Cadete> cadetes = cadeteria.GetCadetes();
                        cadetes[random.Next(0, cadetes.Count)].AsignarPedido(pedido);
                        Console.WriteLine("asignado");
                        pedido = null;
                        break;
                    case 3:

                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            } while (op != 5);
        }
    }
}
