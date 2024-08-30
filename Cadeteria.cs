using tp1.cadete;

namespace tp1.cadeteria
{
    public class Cadeteria
    {
        public string Nombre;
        public List<Cadete> Cadetes;
        public string Telefono;

        public Cadeteria(string nombre, string telefono)
        {
            Cadetes = new List<Cadete>();
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}
