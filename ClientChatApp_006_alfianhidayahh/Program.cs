using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ClientChatApp_006_alfianhidayahh
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new ClientCallback());
            ServiceReference1.ServiceCallbackClient server = new ServiceReference1.ServiceCallbackClient(context);

            Console.WriteLine("Enter username");
            string nama = Console.ReadLine();
            server.gabung(nama);

            Console.WriteLine("Kirim Pesan");
            string pesan = Console.ReadLine();

            //memeriksa apakah pesan null
            while (true)
            {
                if (!string.IsNullOrEmpty(pesan))
                    server.kirimPesan(pesan);
                Console.WriteLine("kirim Pesan");
                pesan = Console.ReadLine();
            }
        }
    }

    public class ClientCallback : ServiceReference1.IServiceCallbackCallback // sebagai context/channel
    {
        public void pesanKirim(string user, string pesan)
        {
            Console.WriteLine("{0}: {1}", user, pesan);
        }
    }
}
