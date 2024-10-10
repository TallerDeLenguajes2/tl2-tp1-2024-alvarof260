public class Cliente
{
    private static int contador = 0;
    private string id;
    private string nombre;
    private string direccion;
    private string telefono;
    private string datosReferenciaDireccion;

    public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion = "")
    {
        this.id = GenerarId();
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.datosReferenciaDireccion = datosReferenciaDireccion;
    }

    private string GenerarId()
    {
        contador++;
        return "CLI-" + contador.ToString("D4");
    }

    public string ObtenerDireccion() { return this.direccion; }
    public string ObtenerNombre() { return this.nombre; }
    public string ObtenerTelefono() { return this.telefono; }
    public string ObtenerDatosReferenciaDireccion() { return this.datosReferenciaDireccion; }


}
