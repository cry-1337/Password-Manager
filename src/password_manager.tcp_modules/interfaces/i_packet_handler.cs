namespace password_manager.tcp_modules.interfaces
{
    public interface i_packet_handler
    {
        public void handle(i_connection connection, i_pending packet);
    }
}
