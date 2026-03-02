using System;
using System.Linq;

namespace Calificicones mejorada
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa para calcular promedio de calificaciones de un estudiante.");

            
            string nombre;
            do
            {
                Console.Write("Ingrese el nombre del estudiante: ");
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("Error: El nombre debe ser texto y no puede estar vacío o solo con espacios.");
                }
                else if (nombre.Any(char.IsDigit))
                {
                    Console.WriteLine("Error: El nombre no debe contener números.");
                }
            } while (string.IsNullOrWhiteSpace(nombre) || nombre.Any(char.IsDigit));

           
            double cal1 = ObtenerCalificacion("Ingrese la primera calificación (0-10): ");
            double cal2 = ObtenerCalificacion("Ingrese la segunda calificación (0-10): ");
            double cal3 = ObtenerCalificacion("Ingrese la tercera calificación (0-10): ");

            
            MostrarPromedioYNivel(nombre, cal1, cal2, cal3);

            Console.ReadKey();
        }

        
        static void MostrarPromedioYNivel(string nom, double c1, double c2, double c3)
        {
           
            double suma = c1 + c2 + c3;
            double promedio = suma / 3;

            string nivel = "";
            if (promedio >= 9) nivel = "Excelente";
            else if (promedio >= 7) nivel = "Bueno";
            else if (promedio >= 6) nivel = "Suficiente";
            else nivel = "Insuficiente";

           
            Console.WriteLine($"\nNombre: {nom}");
            Console.WriteLine($"Promedio: {promedio:F2}");
            Console.WriteLine($"Nivel de aprendizaje: {nivel}");
        }

        static double ObtenerCalificacion(string mensaje)
        {
            double cal;
            do
            {
                Console.Write(mensaje);
                cal = Convert.ToDouble(Console.ReadLine());
                if (cal < 0 || cal > 10) Console.WriteLine("Error: La calificación debe estar entre 0 y 10.");
            } while (cal < 0 || cal > 10);
            return cal;
        }
    }
}
