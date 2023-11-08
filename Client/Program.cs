using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SrvcReference.Service1Client client = new SrvcReference.Service1Client("BasicHttpBinding_IService1");
            Console.WriteLine("Введите пользователя: ");
            string user = Console.ReadLine();
            Console.WriteLine("Введите компанию: ");
            string company = Console.ReadLine();
            client.PostCustInfo(user, company);

            bool ok = true;
            while (ok == true)
            {
                Console.WriteLine("Вы хотите вывести информацию о сотрудниках? да - 1, нет - 0");
                int tmp = int.Parse(Console.ReadLine());
                if (tmp == 1)
                {
                    Console.WriteLine(client.GetAllCustInfo());
                    ok = false;
                }                   
                else Console.WriteLine("Ну и нахуй иди!");
            }
            
            //Console.WriteLine(client.GetTest());


            client.Close();
            Console.ReadLine();
        }
    }
}
