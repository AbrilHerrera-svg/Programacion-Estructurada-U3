using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramaRefactorizadoCalificaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nombres = new List<string>();
            List<List<double>> calificaciones = new List<List<double>>();

            Console.WriteLine("Sistema de Calificaciones de Estudiantes");

            int numEstudiantes;
            do
            {
                Console.Write("¿Cuántos estudiantes desea agregar? (Ingrese un número mayor a 0): ");
                if (!int.TryParse(Console.ReadLine(), out numEstudiantes) || numEstudiantes <= 0)
                {
                    Console.WriteLine("Entrada inválida. Debe ser un número entero mayor a 0.");
                }
            } while (numEstudiantes <= 0);

            for (int j = 0; j < numEstudiantes; j++)
            {
                Console.WriteLine($"\nAgregando estudiante {j + 1}:");

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
                nombres.Add(nombre);

                List<double> cals = new List<double>();
                for (int i = 1; i <= 3; i++)
                {
                    double cal = ObtenerCalificacion($"Ingrese la calificación {i} (0-10): ");
                    cals.Add(cal);
                }
                calificaciones.Add(cals);
            }

            Console.WriteLine("\nResultados:");
            if (nombres.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
            }
            else
            {
                for (int i = 0; i < nombres.Count; i++)
                {
                    double prom = CalcularPromedio(calificaciones[i][0], calificaciones[i][1], calificaciones[i][2]);
                    string nivel = DeterminarNivel(prom);
                    MostrarInformacionEstudiante(nombres[i], prom, nivel);
                }
            }

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }

        static double CalcularPromedio(double c1, double c2, double c3)
        {
            return (c1 + c2 + c3) / 3;
        }

        static string DeterminarNivel(double promedio)
        {
            if (promedio >= 9) return "Excelente";
            else if (promedio >= 7) return "Bueno";
            else if (promedio >= 6) return "Suficiente";
            else return "Insuficiente";
        }

        static void MostrarInformacionEstudiante(string nombre, double promedio, string nivel)
        {
            Console.WriteLine($"\nNombre: {nombre}");
            Console.WriteLine($"Promedio: {promedio:F2}");
            Console.WriteLine($"Nivel de aprendizaje: {nivel}");
        }

        static double ObtenerCalificacion(string mensaje)
        {
            double cal;
            bool esValido;
            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                esValido = double.TryParse(entrada, out cal);

                if (!esValido)
                {
                    Console.WriteLine("Error: Debes ingresar solo un número (Sin décimales) Ejemplo: 8");
                }
                else if (cal < 0 || cal > 10)
                {
                    Console.WriteLine("Error: La calificación debe estar entre 0 y 10.");
                    esValido = false;
                }
            } while (!esValido);

            return cal;
        }
    }
}
