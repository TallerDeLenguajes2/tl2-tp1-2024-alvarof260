using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Cadeteria
{
    [JsonPropertyName("nombre")]
    private string nombre;
    [JsonPropertyName("telefono")]
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;
    private static int gananciaXPedido = 500;

    // relacion por agregracion, ya que los cadetes tiene independencia de la cadeteria
    public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoCadetes = listadoCadetes ?? new List<Cadete>();
        this.listadoPedidos = new List<Pedido>();
    }

    public string ObtenerNombre() { return this.nombre; }
    public string ObtenerTelefono() { return this.telefono; }
    public List<Cadete> ObtenerCadetes() { return this.listadoCadetes; }
    public List<Pedido> ObtenerPedidos() { return this.listadoPedidos; }

    public void AgregarCadetes(Cadete cadete)
    {
        listadoCadetes.Add(cadete);
    }

    public void BorrarCadete(Cadete cadete)
    {
        listadoCadetes.Remove(cadete);
    }

    public void AgregarPedido(Pedido pedido)
    {
        listadoPedidos.Add(pedido);
    }

    public void BorrarPedidos(Pedido pedido)
    {
        this.listadoPedidos.Remove(pedido);
    }

    public int JornalAcobrar(string idCadete)
    {
        Cadete cadete = this.listadoCadetes.Find(c => c.ObtenerId() == idCadete);
        if (cadete != null)
        {
            return this.listadoPedidos.Where(p => p.ObtenerCadeteAsignado() == idCadete).Count() * gananciaXPedido;
        }
        return 0;
    }

    public bool AsignarCadeteAPedido(string idCadete, Pedido pedido)
    {
        Cadete cadete = BuscarCadete(idCadete);
        if (cadete != null)
        {
            pedido.AsignarCadete(cadete);
            AgregarPedido(pedido);
            return true;
        }
        else
        {
            return false;
        }
    }

    private Cadete BuscarCadete(string id)
    {
        Cadete encontrado = this.listadoCadetes.Find(c => c.ObtenerId() == id);
        if (encontrado != null)
        {
            return encontrado;
        }
        else
        {
            return null;
        }
    }

    private Pedido BuscarPedido(string id)
    {
        Pedido encontrado = this.listadoPedidos.Find(p => p.ObtenerNumero() == id);
        if (encontrado != null)
        {
            return encontrado;
        }
        else
        {
            return null;
        }
    }

    public void GenerarInformeDiario()
    {
        var cadetes = this.listadoCadetes;
        int totalPedidos = 0;
        decimal totalGanado = 0;

        Console.WriteLine("---- Informe Diario ----");
        Console.WriteLine("------------------------");

        foreach (var cadete in cadetes)
        {
            var pedidos = this.listadoPedidos;
            int cantidadPedidos = pedidos.Count(p => p.ObtenerCadeteAsignado() == cadete.ObtenerId());
            int montoGanado = JornalAcobrar(cadete.ObtenerId());

            totalPedidos += cantidadPedidos;
            totalGanado += montoGanado;

            Console.WriteLine($"Cadete: {cadete.ObtenerNombre()}");
            Console.WriteLine($"Cantidad de pedidos: {cantidadPedidos}");
            Console.WriteLine($"Monto ganado: {montoGanado:C}");
            Console.WriteLine("------------------------");
        }

        // Calcular el promedio de pedidos por cadete
        decimal promedioEnviosPorCadete = (cadetes.Count() > 0) ? (decimal)totalPedidos / cadetes.Count() : 0;

        Console.WriteLine($"Total de pedidos: {totalPedidos}");
        Console.WriteLine($"Total ganado por todos los cadetes: {totalGanado:C}");
        Console.WriteLine($"Promedio de envíos por cadete: {promedioEnviosPorCadete:F2}");
        Console.WriteLine("------------------------");
    }

    public Pedido DarAltaPedido()
    {
        Console.WriteLine("Datos de cliente\nEscriba una observacion:");
        string obs = Console.ReadLine();
        Console.WriteLine("Escriba un nombre:");
        string nombre = Console.ReadLine();
        Console.WriteLine("Escriba la direccion:");
        string direccion = Console.ReadLine();
        Console.WriteLine("Escriba el telefono:");
        string telefono = Console.ReadLine();
        Console.WriteLine("Escriba un dato de referencia de direccion:");
        string dato = Console.ReadLine();
        return new Pedido(nombre, direccion, telefono, Estado.Pendiente, dato, obs);
    }

    public bool CambiarEstado(string id)
    {
        Pedido pedido = BuscarPedido(id);
        if (pedido != null)
        {
            pedido.CambiarEstado(Estado.Entregado);
            Visual.VerPedidos(new List<Pedido>() { pedido });
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ReasignarPedido(string idCadete, string idPedido)
    {
        Pedido pedido = BuscarPedido(idPedido);
        Cadete cadete = BuscarCadete(idCadete);
        if (pedido != null)
        {
            if (cadete != null)
            {
                pedido.AsignarCadete(cadete);
                Visual.VerCadetes(new List<Cadete>() { cadete });
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}