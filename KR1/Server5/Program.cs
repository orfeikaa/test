using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------WCF-----------");
            using (ServiceHost serviceHost = new ServiceHost(typeof(Service1)))
            {
                serviceHost.Open();
                Console.WriteLine("Сервис запущен...");
                Console.WriteLine("------- Host Info -------");
                Console.WriteLine("Name: " + serviceHost.Description.ConfigurationName);
                Console.WriteLine("PortHttp: " + serviceHost.BaseAddresses[0].Port);
                Console.WriteLine("LocalPathHttp: " + serviceHost.BaseAddresses[0].LocalPath);
                Console.WriteLine("UriHttp: " + serviceHost.BaseAddresses[0].AbsoluteUri);
                Console.WriteLine("SchemeHttp: " + serviceHost.BaseAddresses[0].Scheme);
                Console.WriteLine("PortTcp: " + serviceHost.BaseAddresses[1].Port);
                Console.WriteLine("LocalPathTcp: " + serviceHost.BaseAddresses[1].LocalPath);
                Console.WriteLine("UriTcp: " + serviceHost.BaseAddresses[1].AbsoluteUri);
                Console.WriteLine("SchemeTcp: " + serviceHost.BaseAddresses[1].Scheme);
                Console.WriteLine("----------------------------------------------");
                Console.ReadKey();
            }
        }
    }
}
