namespace tp1
{
    public class Cliente
    {
        private string Nombre { get; set; }
        private string Direccion { get; set; }
        private string Telefono { get; set; }
        private string DatosReferenciaDireccion { get; set; }

        public Cliente(string Nombre, string Direccion, string Telefono, string DatosReferenciaDireccion)
        {
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.DatosReferenciaDireccion = DatosReferenciaDireccion;
        }

        public Cliente(string Nombre, string Direccion, string Telefono)
        {
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.DatosReferenciaDireccion = "";
        }
    }
}