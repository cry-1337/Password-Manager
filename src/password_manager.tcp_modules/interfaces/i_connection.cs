using System.Net;

namespace password_manager.tcp_modules.interfaces
{
    public interface i_connection : IDisposable
    {
        int net_id { get; }
        int port { get; }
        IPAddress ip { get; }

        void begin_read(AsyncCallback callback, object state);

        void begin_write(byte[] buffer, AsyncCallback? callback, object? state);

        int end_read(IAsyncResult ar);

        void block_copy(byte[] received);

        void disconnect();

        bool is_connected();
    }
}
