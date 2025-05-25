using System;
using TP2.models;

namespace TP2.services
{
    /// <summary>       
    /// Esta clase contiene métodos para gestionar empleados, incluyendo la carga de datos, cálculo de sueldo promedio y el empleado con el sueldo más alto.
    /// </summary>
    public class EmpleadosServices
    {
        public Empleado SueldoAsc(Empleado[] lista)
        {
            if (lista == null || lista.Length == 0)
                throw new ArgumentException("La lista no puede estar vacía");

            Empleado empleadoMasAlto = lista[0];

            for (int i = 1; i < lista.Length; i++)
            {
                if ((lista[i].Salario ?? 0) > (empleadoMasAlto.Salario ?? 0))
                {
                    empleadoMasAlto = lista[i];
                }
            }
            return empleadoMasAlto;
        }

        public double SueldoPromedio(Empleado[] lista)
        {
            if (lista == null || lista.Length == 0)
                return 0;

            double sueldoTotal = 0;
            for (int i = 0; i < lista.Length; i++)
            {
                sueldoTotal += lista[i].Salario ?? 0;
            }
            return sueldoTotal / lista.Length;
        }

        public void CargarEmpleados(Empleado[] empleados)
        {
            Console.WriteLine("Por favor, ingrese los datos de "+empleados.Length+" empleados:\n");

            for (int i = 0; i < empleados.Length; i++)
            {
                Console.WriteLine($"--- EMPLEADO {i + 1} ---");

                string nombre = ObtenerNombre();
                string apellido = ObtenerApellido();
                double salario = ObtenerSalario();

                empleados[i] = new Empleado(nombre, apellido, salario);
                Console.WriteLine("Empleado agregado exitosamente!\n");
            }
        }

        static string ObtenerNombre()
        {
            string? nombre;
            do
            {
                Console.Write("Nombre: ");
                nombre = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("Error: El nombre no puede estar vacío.");
                }
                else if (nombre.Length < 3)
                {
                    Console.WriteLine("Error: El nombre debe tener al menos 3 caracteres.");
                }
                else if (!EsSoloLetras(nombre))
                {
                    Console.WriteLine("Error: El nombre solo puede contener letras.");
                }
            } while (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 2 || !EsSoloLetras(nombre));

            return CapitalizarPrimeraLetra(nombre);
        }

        static string ObtenerApellido()
        {
            string? apellido;
            do
            {
                Console.Write("Apellido: ");
                apellido = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(apellido))
                {
                    Console.WriteLine("Error: El apellido no puede estar vacío.");
                }
                else if (apellido.Length < 3)
                {
                    Console.WriteLine("Error: El apellido debe tener al menos 3 caracteres.");
                }
                else if (!EsSoloLetras(apellido))
                {
                    Console.WriteLine("Error: El apellido solo puede contener letras.");
                }
            } while (string.IsNullOrWhiteSpace(apellido) || apellido.Length < 2 || !EsSoloLetras(apellido));

            return CapitalizarPrimeraLetra(apellido);
        }

        static double ObtenerSalario()
        {
            double salario;
            string? input;
            do
            {
                Console.Write("Salario: $");
                input = Console.ReadLine();

                if (!double.TryParse(input, out salario))
                {
                    Console.WriteLine("Error: Ingrese un número válido.");
                }
                else if (salario < 0)
                {
                    Console.WriteLine("Error: El salario no puede ser negativo.");
                }
                else if (salario < 1000)
                {
                    Console.WriteLine("Error: El salario debe ser mayor a $1000.");
                }
            } while (!double.TryParse(input, out salario) || salario < 1000);

            return salario;
        }

        static bool EsSoloLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }

        static string CapitalizarPrimeraLetra(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            return char.ToUpper(texto[0]) + texto.Substring(1).ToLower();
        }

        //##############################################################################################################
        public void MostrarTodosLosEmpleados(Empleado[] empleados)
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE EMPLEADOS ===");
            for (int i = 0; i < empleados.Length; i++)
            {
                Console.WriteLine($"\nEmpleado {i + 1}:");
                Console.WriteLine(empleados[i].ToString());
                Console.WriteLine(new string('-', 30));
            }
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }

        public void MostrarSueldoPromedio(Empleado[] empleados, EmpleadosServices service)
        {
            Console.Clear();
            double promedio = service.SueldoPromedio(empleados);
            Console.WriteLine($"SUELDO PROMEDIO: ${promedio:F2}");
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
        public void MostrarSueldoMasAlto(Empleado[] empleados, EmpleadosServices service)
        {
            Console.Clear();
            Empleado empleadoMasAlto = service.SueldoAsc(empleados);
            Console.WriteLine("EMPLEADO CON SUELDO MÁS ALTO:");
            Console.WriteLine(empleadoMasAlto.ToString());
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
        //##############################################################################################################
        /// <summary>
        /// esta es la funcion que añadi, solo modifica el sueldo
        /// </summary>
        /// <param name="empleados"></param>
        public void ModificarSueldo(Empleado[] empleados)
        {
            Console.Clear();
            Console.WriteLine("=== MODIFICAR SUELDO ===");
            Console.WriteLine("Empleados disponibles:");

            for (int i = 0; i < empleados.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {empleados[i].Nombre} {empleados[i].Apellido} - ${empleados[i].Salario:F2}");
            }

            int indiceEmpleado;
            do
            {
                Console.Write("\nSeleccione el número del empleado (1-5): ");
            } while (!int.TryParse(Console.ReadLine(), out indiceEmpleado) ||
                     indiceEmpleado < 1 || indiceEmpleado > 5);

            indiceEmpleado--; // Convertir a índice de array

            double aumento;
            Console.Write($"\nIngrese el monto de aumento para {empleados[indiceEmpleado].Nombre}: $");
            while (!double.TryParse(Console.ReadLine(), out aumento))
            {
                Console.Write("Ingrese un monto válido: $");
            }

            double salarioAnterior = empleados[indiceEmpleado].Salario ?? 0;
            double nuevoSalario = salarioAnterior + aumento;

            try
            {
                empleados[indiceEmpleado].Salario = nuevoSalario;
                Console.WriteLine($"\n¡Sueldo modificado exitosamente!");
                Console.WriteLine($"Salario anterior: ${salarioAnterior:F2}");
                Console.WriteLine($"Aumento: ${aumento:F2}");
                Console.WriteLine($"Nuevo salario: ${nuevoSalario:F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }
}