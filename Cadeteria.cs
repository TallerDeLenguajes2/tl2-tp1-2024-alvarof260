namespace tp1
{
    public class Cadeteria
    {
        private string Nombre { get; set; }
        private string Telefono { get; set; }
        private List<Cadete> Cadetes { get; set; }

        public Cadeteria(string Nombre, string Telefono, List<Cadete> Cadetes)
        {
            this.Cadetes = Cadetes;
            this.Nombre = Nombre;
            this.Telefono = Telefono;
        }
    }
}
