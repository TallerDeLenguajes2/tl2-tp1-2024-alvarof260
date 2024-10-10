using System.Text.Json;

public abstract class AccesoADatos
{
    public abstract Cadeteria CargarCadeteria(string nombreArchivo);
    public abstract List<Cadete> CargarCadetes(string nombreArchivo);
}

public class AccesoCSV : AccesoADatos
{
    public override Cadeteria CargarCadeteria(string nombreArchivo)
    {
        Cadeteria cadeteria = null;
        string ruta = Path.Combine("archivos", nombreArchivo);
        try
        {
            string[] lineas = File.ReadAllLines(ruta);
            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(",");
                if (datos.Length >= 2)
                {
                    cadeteria = new Cadeteria(datos[0], datos[1], new List<Cadete>());
                }
            }
            if (cadeteria != null)
            {
                return cadeteria;
            }
            else
            {
                throw new Exception("No se pudo cargar la cadetería, archivo vacío o datos incompletos.");
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public override List<Cadete> CargarCadetes(string nombreArchivo)
    {
        List<Cadete> cadetes = new List<Cadete>();
        string ruta = Path.Combine("archivos", nombreArchivo);
        try
        {
            string[] lineas = File.ReadAllLines(ruta);
            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(",");
                if (datos.Length >= 3)
                {
                    cadetes.Add(new Cadete(datos[0], datos[1], datos[2]));
                }
            }
            return cadetes;
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

public class AccesoJSON : AccesoADatos
{
    public override Cadeteria CargarCadeteria(string nombreArchivo)
    {
        try
        {
            string ruta = Path.Combine("archivos", nombreArchivo);
            string json = File.ReadAllText(ruta);
            Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(json);
            return cadeteria;
        }
        catch
        {
            Console.WriteLine("No se pudo cargar los datos de cadeteria");
        }
        return null;
    }

    public override List<Cadete> CargarCadetes(string nombreArchivo)
    {
        try
        {
            string ruta = Path.Combine("archivos", nombreArchivo);
            string json = File.ReadAllText(ruta);
            List<Cadete> cadetes = JsonSerializer.Deserialize<List<Cadete>>(json);
            return cadetes;
        }
        catch
        {
            Console.WriteLine("No se pudo cargar los datos de los cadetes");
        }
        return null;
    }
}