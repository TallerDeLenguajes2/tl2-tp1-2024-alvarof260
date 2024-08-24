using tp1.cadete;

namespace tp1.cadeteria
{
    class Cadeteria
    {
        private string Nombre;
        public List<Cadete> Cadetes;
        private string Telefono;

        public Cadeteria(string nombre, string telefono)
        {
            Cadetes = new List<Cadete>();
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}
