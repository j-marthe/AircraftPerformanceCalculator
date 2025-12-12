using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        int menu = 0;

        string patronRegex = "^[0-5]$";

        Aircraft aircraft = null;
        FlightConditions conditions = null;

        while (menu != 5)
        {
            Console.WriteLine("Bienvenido a la Calculadora de Performance de Avión");
            Console.WriteLine("1. Ingresar datos del avión");
            Console.WriteLine("2. Calcular performance");
            Console.WriteLine("3. Mostrar resultados");
            Console.WriteLine("4. Guardar resultados");
            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción:");
            string respuestaMenu = Console.ReadLine();

            if(!Regex.IsMatch(respuestaMenu, patronRegex))
            {
                Console.WriteLine("Por favor, introduce un valor aceptado");
                Console.WriteLine("");

                respuestaMenu = "0";
            }

            menu = int.Parse(respuestaMenu);


            switch (menu)
            {
                case 1:
                    aircraft = AddAvion();
                    conditions = AddCondiciones();
                    break;
                case 2:
                    Console.WriteLine("Calculos Avion");
                    break;
                case 3:
                    Console.WriteLine("Mostrar resultados");
                    break;
                case 4:
                    Console.WriteLine("Guardar resultados");
                    break;
                
            }


        }

    }

    private static Aircraft AddAvion()
    {
        Aircraft aircraft = new Aircraft();

        Console.Write("Ingrese nombre del avión:");
        string nombre = Console.ReadLine();
        aircraft.Name = nombre;

        Console.Write("Ingrese MTOW (kg):");
        double mtow;
        while (!double.TryParse(Console.ReadLine(), out mtow))
        {
            Console.WriteLine("Valor inválido. Intente de nuevo:");
        }
        aircraft.MTOW = mtow;

        Console.Write("Ingrese peso actual (kg):");
        double weight;
        while (!double.TryParse(Console.ReadLine(), out weight))
        {
            Console.WriteLine("Valor inválido. Intente de nuevo:");
        }
        aircraft.CurrentWeight = weight;

        Console.Write("Ingrese flap setting (grados):");
        double flapSetting;
        while (!double.TryParse(Console.ReadLine(), out flapSetting))
        {
            Console.WriteLine("Valor inválido. Intente de nuevo:");
        }
        aircraft.FlapSetting = flapSetting;


        return aircraft;

    }

    private static FlightConditions AddCondiciones()
    {
        FlightConditions conditions = new FlightConditions();

        Console.Write("Ingrese longitud de pista (m):");
        double runway;
        while (!double.TryParse(Console.ReadLine(), out runway))
        {
            Console.WriteLine("Valor inválido. Intente de nuevo:");
        }
        conditions.RunwayLength = runway;

        Console.Write("Ingrese temperatura (°C)");
        double grade;
        while (!double.TryParse(Console.ReadLine(), out grade))
        {
            Console.WriteLine("Valor inválido. Intente de nuevo:");
        }
        conditions.Temperature = grade;

        
        return conditions;

    }
}