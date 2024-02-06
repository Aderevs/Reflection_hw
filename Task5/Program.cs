using System;
using System.IO;
using System.Reflection;
using TemperatureLibrary;

namespace LoadAssembly
{
    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(80, 50);

            Assembly assembly = null;

            try
            {
                assembly = Assembly.LoadFrom("..\\..\\..\\..\\TemperatureLibrary\\bin\\Debug\\net8.0\\TemperatureLibrary.dll");
                Console.WriteLine("Loaded assembly");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ListAllTypes(assembly);
            ListAllMembers(assembly);
            GetParams(assembly);
        }

        private static void ListAllTypes(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));
            Console.WriteLine("\nListAllTypes in: {0} \n", assembly.FullName);

            Type[] types = assembly.GetTypes();

            foreach (Type t in types)
                Console.WriteLine("Type: {0}", t);
        }

        private static void ListAllMembers(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));

            Type type = assembly.GetType("TemperatureLibrary.Temperature");

            Console.WriteLine("\nListAllMembers for: {0} \n", type);

            MemberInfo[] members = type.GetMembers();

            foreach (MemberInfo element in members)
                Console.WriteLine("{0,-15}:  {1}", element.MemberType, element);
        }

        private static void GetParams(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));

            Type type = assembly.GetType("TemperatureLibrary.Temperature");
            MethodInfo method = type.GetMethod("ConvertToOtherMeasurementUnits", new Type[] { typeof(MeasurementUnits) }); // Equals , Acceleration, Driver

            Console.WriteLine("\nGetParams for method {0}", method.Name);
            ParameterInfo[] parameters = method.GetParameters();
            Console.WriteLine("Params length: " + parameters.Length);

            foreach (ParameterInfo parameter in parameters)
            {
                Console.WriteLine("parameter.Name: {0}", parameter.Name);
                Console.WriteLine("parameter.Position: {0}", parameter.Position);
                Console.WriteLine("parameter.ParameterType: {0}", parameter.ParameterType);
            }
        }
    }
}
