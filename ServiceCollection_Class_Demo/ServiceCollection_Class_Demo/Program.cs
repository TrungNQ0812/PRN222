using System;
using System.Collections;
using ServiceCollection_Class_Demo.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Xml;

namespace ServiceCollection_Class_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DI-ServiceC011ection Class";
            var services = new ServiceCollection();
            services.AddTransient<IXMLWriter, Writer>();
            services.AddScoped<IJSONWriter, JSONWriter>();
            var provider = services.BuildServiceProvider();
            Console.WriteLine("Dependency Injection Demo");
            Console.WriteLine("Mapping Interfaces to instance classes");
            Console.WriteLine("---------------------");
            Console.WriteLine("P1ease, select message format (1) : XML | (2) : JSON");
            Console.ReadLine();
            var res = Console.ReadLine();
            if (res == "1") {
                var XMLInstance = provider.GetService<Writer>();
                XMLInstance.WriteXML();
            }
            else {
                var JSONInstance =  provider.GetService<IJSONWriter>();
                JSONInstance.WriteJSON();
            }
            
            var registeredXMLServices = provider.GetServices<IXMLWriter>();
            foreach (var svc in registeredXMLServices)
            {
                Console.WriteLine($"Service Name: {svc.ToString()}");
            }
            Console.WriteLine(new string('*', 20));

            foreach (var svc in services)
            {
                Console.WriteLine($"Type: {svc.ImplementationType} \n " +
                    $"Lifetime: {svc.Lifetime} \n " +
                    $"Service type: {svc.ServiceType}");
            }
            Console. ReadLine();
        }
    }
}
