public class Visual
{
    public static void MenuPrincipal()
    {
        Console.WriteLine("\t\t\t------ MENU -------");
        Console.WriteLine("1: alta pedido");
        Console.WriteLine("2: asignar pedido");
        Console.WriteLine("3: cambiar de estado de pedido");
        Console.WriteLine("4: reasignar pedido a otro cadete");
        Console.WriteLine("5: jornal a pagar");
        Console.WriteLine("0: salir");
        Console.WriteLine("\t\t\t-- seleccione una opcion --");
    }

    public static void VerCadetes(List<Cadete> cadetes)
    {
        Console.WriteLine("\t\t\t-* Cadetes *-");
        foreach (var cadete in cadetes)
        {
            Console.WriteLine($"id: {cadete.ObtenerId()}, nombre: {cadete.ObtenerNombre()}");
        }
    }

    public static void VerPedidos(List<Pedido> pedidos)
    {
        Console.WriteLine("\t\t\t-* Pedidos *-");
        foreach (var pedidoc in pedidos)
        {
            Console.WriteLine($"Nombre: {pedidoc.ObtenerNombre()}, Numero: {pedidoc.ObtenerNumero()}, Estado:{pedidoc.ObtenerEstado()}");
            Console.WriteLine("\t\t\t*-*-*-*");
        }
    }

    public static void MenuAcceso()
    {
        Console.WriteLine("Como cargamos los datos?:");
        Console.WriteLine("1: JSON");
        Console.WriteLine("2: CSV");
    }
}