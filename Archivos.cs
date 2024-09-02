namespace tp1
{

    public class Archivos
    {
        public static List<Cadeteria> LeerCadeterias(string ruta)
        {
            List<Cadeteria> lista = new List<Cadeteria>();
            try
            {
                string[] lineas = File.ReadAllLines(ruta);
                foreach (var linea in lineas)
                {
                    string[] datos = linea.Split(",");
                    Cadeteria cadeteria = new Cadeteria(datos[0], datos[1]);
                    lista.Add(cadeteria);
                }
                return lista;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public static Cadeteria ObtenerElPrimero(string ruta)
        {
            return LeerCadeterias(ruta).ElementAt(0);
        }

        public static List<Cadete> ListaDeCadetes(string ruta)
        {
            List<Cadete> lista = new List<Cadete>();
            string[] lineas = File.ReadAllLines(ruta);
            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(",");
                Cadete cadete = new Cadete(datos[0], datos[1], datos[2]);
                lista.Add(cadete);
            }
            return lista;
        }

        public static bool Existe(string ruta)
        {
            return File.Exists(ruta) && new FileInfo(ruta).Length > 0;
        }
    }

}