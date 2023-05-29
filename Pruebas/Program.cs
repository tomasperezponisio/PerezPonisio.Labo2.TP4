using System;
using Entidades;

namespace Pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string mesActual = DateTime.Now.ToString("MM");
            //string anioActual = DateTime.Now.ToString("yyyy");
            //Console.WriteLine($"{mesActual}");
            //Console.WriteLine($"{anioActual}");

            Socio s1 = new Socio("Tomas", "Perez", 31443243, new DateTime(1985,02,24), Socio.EActividad.Natacion, Socio.ECategoria.Adulto);
            Console.WriteLine($"edad desde la propiedad: {s1.Edad}");
            Console.WriteLine($"fecha de nac: {s1.FechaNacimiento}");
        }
    }
}
