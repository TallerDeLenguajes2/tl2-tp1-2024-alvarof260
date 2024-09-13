using System.Text.Json;
using System.IO;

namespace tp1
{
    public abstract class AccesoADatos
    {
        public abstract Cadeteria CargarCadeteria();
        public abstract List<Cadete> CargarCadetes();
    }

    public class AccesoCSV : AccesoADatos
    {
        private string rutaCadeteria;
        private string rutaCadetes;


        public AccesoCSV(string rutaCadeteria, string rutaCadetes)
        {
            this.rutaCadeteria = rutaCadeteria;
            this.rutaCadetes = rutaCadetes;
        }

        public override Cadeteria CargarCadeteria()
        {
            string[] lineas = File.ReadAllLines(rutaCadeteria);
            string[] datos = lineas[0].Split(",");
            return new Cadeteria(datos[0], datos[1]);
        }

        public override List<Cadete> CargarCadetes()
        {
            List<Cadete> cadetes = new List<Cadete>();
            string[] lineas = File.ReadAllLines(rutaCadetes);
            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(",");
                Cadete cadete = new Cadete(datos[0], datos[1], datos[2]);
                cadetes.Add(cadete);
            }
            return cadetes;
        }


    }

    public class AccesoJSON : AccesoADatos
    {
        private string rutaCadeteria;
        private string rutaCadetes;

        public AccesoJSON(string rutaCadeteria, string rutaCadetes)
        {
            this.rutaCadeteria = rutaCadeteria;
            this.rutaCadetes = rutaCadetes;
        }

        public override Cadeteria CargarCadeteria()
        {
            string json = File.ReadAllText(rutaCadeteria);
            return JsonSerializer.Deserialize<Cadeteria>(json);
        }

        public override List<Cadete> CargarCadetes()
        {
            string json = File.ReadAllText(rutaCadetes);
            return JsonSerializer.Deserialize<List<Cadete>>(json);
        }
    }
}