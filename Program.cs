class Program
{
    public static void Main()
    {
        Cadeteria cadeteria = null;
        List<Cadete> cadetes = null;
        int op = 0;
        Pedido pedido = null;
        string idCadete, idPedido;

        Visual.MenuAcceso();

        while (!int.TryParse(Console.ReadLine(), out op) || op < 1 || op > 2)
        {
            Console.WriteLine("Intente de nuevo, opcion incorrecta.");
        }
        switch (op)
        {
            case 1:
                AccesoJSON accesoJSON = new AccesoJSON();
                cadeteria = accesoJSON.CargarCadeteria("cadeteria.json");
                cadetes = accesoJSON.CargarCadetes("cadetes.json");
                break;
            case 2:
                AccesoCSV accesoCSV = new AccesoCSV();
                cadeteria = accesoCSV.CargarCadeteria("cadeteria.csv");
                cadetes = accesoCSV.CargarCadetes("cadetes.csv");
                break;
        }

        foreach (var cadete in cadetes)
        {
            cadeteria.AgregarCadetes(cadete);
        }

        do
        {
            Visual.MenuPrincipal();
            if (int.TryParse(Console.ReadLine(), out op) == false)
            {
                Console.WriteLine("caracter incorrecto");
                Console.ReadKey();
            }
            else if (op < 0 || op > 5)
            {
                Console.WriteLine("eligio una opcion inexistente, vuelva a intentar");
                Console.ReadKey();
            }

            switch (op)
            {
                case 1:
                    Console.WriteLine("Dar de alta pedido");
                    pedido = cadeteria.DarAltaPedido();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Asignar pedido a cadete");
                    Visual.VerCadetes(cadeteria.ObtenerCadetes());
                    Console.WriteLine("Ingrese ID de cadete:");
                    idCadete = Console.ReadLine();
                    cadeteria.AsignarCadeteAPedido(idCadete, pedido);
                    pedido = null;
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Cambiar de estado a pedido");
                    Visual.VerPedidos(cadeteria.ObtenerPedidos().Where(p => p.ObtenerEstado() == Estado.Asignado).ToList());
                    Console.WriteLine("Ingrese ID de pedido:");
                    idPedido = Console.ReadLine();
                    cadeteria.CambiarEstado(idPedido);
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("Cambiar el cadete a pedido");
                    Visual.VerPedidos(cadeteria.ObtenerPedidos().Where(p => p.ObtenerEstado() == Estado.Asignado).ToList());
                    Console.WriteLine("Ingrese ID de pedido:");
                    idPedido = Console.ReadLine();
                    Visual.VerCadetes(cadeteria.ObtenerCadetes());
                    Console.WriteLine("Ingrese ID de cadete:");
                    idCadete = Console.ReadLine();
                    cadeteria.ReasignarPedido(idCadete, idPedido);
                    Console.ReadKey();
                    break;
                case 5:
                    Console.WriteLine("Jornal de cadete");
                    Visual.VerCadetes(cadeteria.ObtenerCadetes());
                    Console.WriteLine("Ingrese ID de cadete:");
                    idCadete = Console.ReadLine();
                    int jornal = cadeteria.JornalAcobrar(idCadete);
                    Console.WriteLine($"Jornal a cobrar: {jornal}");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();
        } while (op != 0);
        cadeteria.GenerarInformeDiario();
        Console.ReadKey();
    }
}