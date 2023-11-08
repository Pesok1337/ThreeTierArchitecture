using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wcfPostgreSQL;
using System.ServiceModel;


namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(wcfPostgreSQL.Service1)))
            {
                host.Open();
                Console.WriteLine("Host started.");
                Console.ReadLine();
            }
        }
    }
}
