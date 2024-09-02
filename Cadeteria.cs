namespace tp1
{
    public class Cadeteria
    {
        private string Nombre { get; set; }
        private string Telefono { get; set; }
        private List<Cadete> Cadetes { get; set; }

        public Cadeteria(string Nombre, string Telefono)
        {
            this.Cadetes = new List<Cadete>();
            this.Nombre = Nombre;
            this.Telefono = Telefono;
        }

        public string GetNombre()
        {
            return this.Nombre;
        }

        public void AddCadete(Cadete cadete)
        {
            this.Cadetes.Add(cadete);
        }

        public List<Cadete> GetCadetes()
        {
            return this.Cadetes;
        }

    }
}
