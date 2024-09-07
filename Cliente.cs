namespace tp1
{
    public class Cliente
    {
        public string Nombre { get; private set; }
        public string Direccion { get; private set; }
        public string Telefono { get; private set; }
        public string DatosReferenciaDireccion { get; private set; }

        public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion = "")
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.DatosReferenciaDireccion = datosReferenciaDireccion;
        }
    }
}