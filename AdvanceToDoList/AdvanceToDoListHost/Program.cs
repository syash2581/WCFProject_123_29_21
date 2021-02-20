using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceToDoListHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(AdvanceToDoList.UserService);
            Type t2 = typeof(AdvanceToDoList.ToDoService);
            Uri tcp = new Uri("net.tcp://localhost:8010/ToDo/User");
            Uri tcp2 = new Uri("net.tcp://localhost:8010/ToDo/ToDo");
            Uri http = new Uri("http://localhost:8000/ToDo/User");
            Uri http2 = new Uri("http://localhost:8000/ToDo/ToDo");

            ServiceHost host = new ServiceHost(t, tcp, http);
            ServiceHost host2 = new ServiceHost(t2, tcp2, http2);


            host.Open();
            Console.WriteLine("Published host 1");
            host2.Open();
            Console.WriteLine("Published host 2");
            Console.ReadLine();
            host.Close();
            host2.Close();
        }
    }
}
