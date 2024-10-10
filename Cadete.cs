using System.Text.Json.Serialization;

public class Cadete
{
    private static int contador = 0;
    private string id;
    [JsonPropertyName("nombre")]
    private string nombre;
    [JsonPropertyName("direccion")]
    private string direccion;
    [JsonPropertyName("telefono")]
    private string telefono;

    public Cadete(string nombre, string direccion, string telefono)
    {
        this.id = generarId();
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }

    private string generarId()
    {
        contador++;
        return "CAD-" + contador.ToString("D4");
    }

    public string ObtenerId() { return this.id; }
    public string ObtenerNombre() { return this.nombre; }
    public string ObtenerDireccion() { return this.direccion; }
    public string ObtenerTelefono() { return this.telefono; }
}
