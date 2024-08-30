﻿using System;
using tp1.cliente;
using tp1.pedido;
using tp1.cadete;
using tp1.cadeteria;
using tp1.data;

partial class Program
{
    public static void Main()
    {
        string ruta = "cadeteria.csv";
        string nombre;
        string telefono;
        Cadeteria cadeteria;

        if (!Archivos.Existe(ruta))
        {
            Console.WriteLine("Hola. Por favor, ingrese el nombre de la Cadeteria: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Por favor, ingrese el telefono de la Cadeteria: ");
            telefono = Console.ReadLine();
            cadeteria = new Cadeteria(nombre, telefono);
        }

        try
        {
            cadeteria = Archivos.ObtenerElPrimero(ruta);
        }
        catch (System.Exception)
        {
            Console.WriteLine("Pibe no tenes el archivo.");
            throw;
        }

        Console.WriteLine(cadeteria.Nombre);

        Console.ReadKey();
        Console.Clear();

        int opcion;

        do
        {
            Console.WriteLine("1. Agregar Cadete");
            Console.WriteLine("2. Mostrar Cadetes");
            Console.WriteLine("3. Salir");
            Console.WriteLine("Opcion: ");
            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Por favor, ingrese el nombre del Cadete: ");
                    string nombreCadete = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese la direccion del Cadete: ");
                    string direccion = Console.ReadLine();
                    Console.WriteLine("Por favor, ingrese el telefono del Cadete: ");
                    string telefonoCadete = Console.ReadLine();
                    Cadete cadete = new Cadete(nombreCadete, direccion, telefonoCadete);
                    cadeteria.Cadetes.Add(cadete);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Cadetes: ");
                    foreach (Cadete p in cadeteria.Cadetes)
                    {
                        Console.WriteLine(p.Nombre);
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
            Console.Clear();
        } while (opcion != 3);
    }
}
