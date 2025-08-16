using password_manager.tcp_modules.interfaces;
using password_manager.tcp_modules.modules;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace password_manager.server.network
{
    public class listener
    {
        private readonly TcpListener tcp_listener;
        private readonly object locker = new();
        private readonly i_netid_manager netid_manager;
        private readonly i_packet_handler packet_handler;
        private readonly ConcurrentDictionary<int, i_connection> clients = new();

        public listener(IPAddress ip, int port, i_netid_manager inetid, i_packet_handler packet_handler)
        {
            netid_manager = inetid;
            tcp_listener = new(ip, port);

            this.packet_handler = packet_handler;

            Console.WriteLine("started server");

            try
            {
                tcp_listener.Start();
                accept_loop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void accept_loop()
        {
            while (true)
            {
                try
                {
                    TcpClient tcp_client = await tcp_listener.AcceptTcpClientAsync();
                    if (tcp_client.Client.RemoteEndPoint is IPEndPoint ip_end_point)
                        create_connection(ip_end_point, tcp_client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void create_connection(IPEndPoint ip_end_point, TcpClient tcp_client)
        {
            try
            {
                int id = netid_manager.free_id();
                i_connection connection = new connection(ip_end_point.Address, ip_end_point.Port, id, tcp_client);
                lock (locker) clients[id] = connection;
                connection.begin_read(read_client_connection, connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void read_client_connection(IAsyncResult ar)
        {
            try
            {
                if (ar.AsyncState is not i_connection connection) return;

                int size = 0;
                try { size = connection.end_read(ar); } catch { connection.Dispose(); return; }

                if (size == 0)
                {
                    connection.Dispose();
                    return;
                }

                byte[] received_bytes = new byte[size];
                connection.block_copy(received_bytes);

                pending packet = new pending(received_bytes, size);
                handle_client_connection(connection, packet);

                if (connection.is_connected())
                    connection.begin_read(read_client_connection, connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void handle_client_connection(i_connection connection, pending packet)
            => packet_handler.handle(connection, packet);
    }
}
