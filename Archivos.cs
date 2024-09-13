using System.Text.Json;
using System.IO;

namespace tp1
{
    public abstract class AccesoADatos
    {
        public abstract List<Cadete> CargarCadetes(string ruta);
        public abstract List<Pedido> CargarPedidos(string ruta);
    }

    public class AccesoCSV : AccesoADatos
    {
        public override List<Cadete> CargarCadetes(string ruta)
        {
            List<Cadete> cadetes = new List<Cadete>();
            string[] lineas = File.ReadAllLines(ruta);

            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(",");
                Cadete cadete = new Cadete(datos[0], datos[1], datos[2]);
                cadetes.Add(cadete);
            }
            return cadetes;
        }

        public override List<Pedido> CargarPedidos(string ruta)
        {
            List<Pedido> pedidos = new List<Pedido>();
            string[] lineas = File.ReadAllLines(ruta);

            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(",");
                Pedido pedido = new Pedido(datos[0], datos[1], datos[2], datos[3], datos[4]);
                pedidos.Add(pedido);
            }
            return pedidos;
        }
    }

    public class AccesoJSON : AccesoADatos
    {
        public override List<Cadete> CargarCadetes(string ruta)
        {
            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Cadete>>(json);
        }

        public override List<Pedido> CargarPedidos(string ruta)
        {
            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Pedido>>(json);
        }
    }


}