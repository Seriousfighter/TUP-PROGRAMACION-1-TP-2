using System;
using TP2.models;
using TP2.services;

namespace TP2
{
    class Program
    {
        static void Main(string[] args)
        {

            /// <summary>
            /// Verificar si se pasó un argumento para la cantidad de empleados
            /// esto permite al usuario especificar la cantidad de empleados a cargar
            /// al ejecutar el programa, por ejemplo: dotnet run 10
            /// Si no se pasa un argumento, se cargan 5 empleados por defecto
            /// Cosas a mejorar:
            /// - abstraer la logica de validacion.
            /// - abstarer el menu.
            /// - pasar empleados por referencia.
            /// </summary>
            int cantidadEmpleados = (args.Length > 0 && int.TryParse(args[0], out int n) && n > 0) ? n : 5;

            Empleado[] empleados = new Empleado[cantidadEmpleados];
            // Crear una instancia de EmpleadosServices
            EmpleadosServices empleadosServices = new EmpleadosServices();

            Console.WriteLine("=== SISTEMA DE GESTIÓN DE EMPLEADOS ===\n");

            // Cargar datos de 5 empleados
            empleadosServices.CargarEmpleados(empleados);

            // Mostrar menú de gestión
            MostrarMenuGestion(empleados, empleadosServices);
        }

        

        static void MostrarMenuGestion(Empleado[] empleados, EmpleadosServices service)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ DE GESTIÓN DE EMPLEADOS ===");
                Console.WriteLine("1. Mostrar sueldo promedio");
                Console.WriteLine("2. Mostrar empleado con sueldo más alto");
                Console.WriteLine("3. Modificar sueldo de empleado");
                Console.WriteLine("4. Mostrar todos los empleados");
                Console.WriteLine("5. Salir");
                Console.Write("\nSeleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            service.MostrarSueldoPromedio(empleados, service);
                            break;
                        case 2:
                           service.MostrarSueldoMasAlto(empleados, service);
                            break;
                        case 3:
                            service.ModificarSueldo(empleados);
                            break;
                        case 4:
                            service.MostrarTodosLosEmpleados(empleados);
                            break;
                        case 5:
                            Console.WriteLine("¡Gracias por usar el sistema!");
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Presione Enter para continuar...");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Presione Enter para continuar...");
                    Console.ReadLine();
                }
            } while (opcion != 5);
        }
        
    }
}