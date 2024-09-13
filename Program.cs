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
