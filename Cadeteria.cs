namespace tp1
{
    public class Cadeteria
    {
        public string Nombre { get; private set; }
        public string Telefono { get; private set; }
        private List<Cadete> Cadetes { get; set; }

        public Cadeteria(string Nombre, string Telefono, List<Cadete> Cadetes = null)
        {
            this.Nombre = Nombre;
            this.Telefono = Telefono;
            this.Cadetes = Cadetes ?? new List<Cadete>();
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
