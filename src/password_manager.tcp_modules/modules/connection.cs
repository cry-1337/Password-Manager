using password_manager.tcp_modules.interfaces;
using System.Net;
using System.Net.Sockets;

namespace password_manager.tcp_modules.modules
{
    public class connection(IPAddress _ip, int _port, int id, TcpClient tcp_client) : i_connection
    {
        private byte[] buffer = new byte[tcp_client.ReceiveBufferSize];

        private bool _disposed = false;

        public int net_id => id;

        public IPAddress ip => _ip;

        public int port => _port;

        public NetworkStream stream => tcp_client.GetStream();

        public void begin_read(AsyncCallback callback, object state) => stream.BeginRead(buffer, 0, buffer.Length, callback, state);

        public void begin_write(byte[] buffer, AsyncCallback? callback, object? state) => stream.BeginWrite(buffer, 0, buffer.Length, callback, state);

        public int end_read(IAsyncResult ar) => stream.EndRead(ar);

        public void block_copy(byte[] received) => Buffer.BlockCopy(buffer, 0, received, 0, received.Length);

        public void disconnect()
        {
            _disposed = true;
            tcp_client.Dispose();
        }

        public bool is_connected() => !_disposed;

        public void Dispose() => disconnect();
    }
}
