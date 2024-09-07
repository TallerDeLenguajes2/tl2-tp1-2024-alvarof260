namespace tp1
{
    public class Cadeteria
    {
        public string Nombre { get; private set; }
        public string Telefono { get; private set; }
        private List<Cadete> Cadetes { get; set; }

        public Cadeteria(string nombre, string telefono, List<Cadete> cadetes = null)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Cadetes = cadetes ?? new List<Cadete>();
        }

        public void AgregarCadete(Cadete cadete)
        {
            this.Cadetes.Add(cadete);
        }

        public List<Cadete> ObtenerCadetes()
        {
            return this.Cadetes;
        }

    }
}
