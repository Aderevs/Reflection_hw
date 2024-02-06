using System.Reflection;
using TemperatureLibrary;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFrom("E:\\CyberByonicSystematics\\C# Professional\\Homeworkes\\Reflection_hw\\TemperatureLibrary\\bin\\Debug\\net8.0\\TemperatureLibrary.dll");
                Console.WriteLine("Loaded CarLibrary assembly");
                Type type = assembly.GetType("TemperatureLibrary.Temperature");

                ITemperature temperatureInstance = Activator.CreateInstance(type) as ITemperature;


                if (temperatureInstance != null)
                {
                    Console.WriteLine("enter measurement units you want too see temperature of freezing water");
                    Console.WriteLine("1. Celsium;  2. Farenheit;   3. Kelvin");
                    byte choice = byte.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            temperatureInstance.ConvertToOtherMeasurementUnits(MeasurementUnits.Farenheit);
                            break;
                        case 3:
                            temperatureInstance.ConvertToOtherMeasurementUnits(MeasurementUnits.Kelvin);
                            break;
                        default:
                            Console.WriteLine("there is no such option:(");
                            break;
                    }

                    Console.WriteLine(temperatureInstance);
                }
                Type[] parameterTypes = { typeof(double), typeof(string) };
                ConstructorInfo constructor = type.GetConstructor(parameterTypes);
                if (constructor != null)
                {
                    double degrees;
                    string measurementUnits;
                    Console.WriteLine("enter temperature and emasurement units:");
                    degrees = double.Parse(Console.ReadLine());
                    measurementUnits = Console.ReadLine();
                    object[] parameters = { degrees, measurementUnits };
                    var instance = constructor.Invoke(parameters) as ITemperature;
                    Console.WriteLine(instance);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n\n\n\n");
            /*ListAllTypes(assembly);
            ListAllMembers(assembly);
            GetParams(assembly);*/


        }
    }
}
