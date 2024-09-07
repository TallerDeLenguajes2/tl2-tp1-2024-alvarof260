namespace tp1
{

    public class Archivos
    {

        public static List<T> LeerArchivo<T>(string ruta, Func<string[], T> procesarLinea)
        {
            List<T> lista = new List<T>();

            if (!Existe(ruta))
            {
                Console.WriteLine($"El archivo en la ruta {ruta} no existe o está vacío.");
                return lista;
            }

            try
            {
                string[] lineas = File.ReadAllLines(ruta);
                foreach (var linea in lineas)
                {
                    string[] datos = linea.Split(",");
                    T item = procesarLinea(datos);
                    if (item != null)
                    {
                        lista.Add(item);
                    }
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Error al leer el archivo en la ruta {ruta}: {e.Message}");
                throw new IOException($"Error al procesar el archivo en {ruta}", e);
            }

            return lista;
        }

        public static List<Cadeteria> ListaDeCadeterias(string ruta)
        {
            return LeerArchivo<Cadeteria>(ruta, datos =>
            {
                if (datos.Length < 2)
                {
                    Console.WriteLine($"Formato incorrecto en la línea: {string.Join(",", datos)}");
                    return null;
                }

                return new Cadeteria(datos[0], datos[1]);
            });
        }

        public static List<Cadete> ListaDeCadetes(string ruta)
        {
            return LeerArchivo<Cadete>(ruta, datos =>
            {
                if (datos.Length < 3)
                {
                    Console.WriteLine($"Formato incorrecto en la línea: {string.Join(",", datos)}");
                    return null;
                }

                return new Cadete(datos[0], datos[1], datos[2]);
            });
        }

        public static Cadeteria ObtenerElPrimero(string ruta)
        {
            return ListaDeCadeterias(ruta).FirstOrDefault();
        }

        public static bool Existe(string ruta)
        {
            return File.Exists(ruta) && new FileInfo(ruta).Length > 0;
        }
    }

}