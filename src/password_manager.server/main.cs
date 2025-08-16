using password_manager.server.managers;
using password_manager.server.network;
using System.Net;

namespace password_manager.server
{
    public class program
    {
        public static int port = 21013;

        private static void Main(string[] args)
        {
            new listener(IPAddress.Any, port, new netid_manager(), new packet_handler());
            Console.ReadKey();
        }
    }
}