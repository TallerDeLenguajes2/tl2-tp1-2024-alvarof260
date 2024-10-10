
public enum Estado
{
    Pendiente,
    Asignado,
    Entregado,
}
public class Pedido
{
    private static int contador = 0;
    private string numero;
    private string observacion;
    private Cliente cliente;
    private Estado estado;
    private Cadete cadeteAsignado;

    public Pedido(string nombre, string direccion, string telefono, Estado estado, string datosReferenciaDireccion = "", string observacion = "")
    {
        this.numero = GenerarNumero();
        this.observacion = observacion;
        this.cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
        this.estado = estado;
        this.cadeteAsignado = null;
    }

    private string GenerarNumero()
    {
        contador++;
        return contador.ToString("D4");
    }

    public Estado ObtenerEstado() { return this.estado; }
    public string ObtenerNumero() { return this.numero; }
    public string ObtenerNombre() { return this.cliente.ObtenerNombre(); }
    public string ObtenerCadeteAsignado() { return this.cadeteAsignado.ObtenerId(); }

    public void VerDireccionCliente()
    {
        Console.WriteLine($"Direccion de cliente: {this.cliente.ObtenerDireccion()}");
    }
    public void VerDatosCliente()
    {
        Console.WriteLine("-*-*-* Informacion *-*-*-");
        Console.WriteLine($"nombre: {this.cliente.ObtenerNombre()}");
        Console.WriteLine($"direccion: {this.cliente.ObtenerDireccion()}");
        Console.WriteLine($"telefono: {this.cliente.ObtenerTelefono()}");
        Console.WriteLine($"datos referencia de direccion: {this.cliente.ObtenerDatosReferenciaDireccion()}");
    }

    public void CambiarEstado(Estado estado)
    {
        this.estado = estado;
    }

    public void AsignarCadete(Cadete cadete)
    {
        this.cadeteAsignado = cadete;
        this.CambiarEstado(Estado.Asignado);

    }
}
