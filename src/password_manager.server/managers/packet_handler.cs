using password_manager.tcp_modules.interfaces;
using System.Text;

namespace password_manager.server.managers
{
    public class packet_handler : i_packet_handler
    {
        public void handle(i_connection connection, i_pending packet)
        {
            try
            {
                Console.WriteLine($"[{DateTime.Now}] [{connection.net_id}] {connection.ip} sent packet with size {packet.size}. " +
                    $"in string format: {Encoding.ASCII.GetString(packet.contents)}");

                connection.begin_write(ASCIIEncoding.UTF32.GetBytes("testing this"), null, null);
                Console.WriteLine($"[+] authorized {connection.ip} [{connection.net_id}]");
                connection.disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
