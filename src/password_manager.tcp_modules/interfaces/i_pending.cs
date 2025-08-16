namespace password_manager.tcp_modules.interfaces
{
    public interface i_pending
    {
        public int size { get; set; }
        public byte[] contents { get; set; }
    }
}
