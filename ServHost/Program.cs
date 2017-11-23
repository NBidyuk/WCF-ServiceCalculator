using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServHost
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ServiceHost serviceHost = new ServiceHost(typeof(Calculator.Calculator)))
            {
                serviceHost.Open();
                Console.WriteLine("Host open...");
                Console.ReadLine();
            }


        }
    }
}
