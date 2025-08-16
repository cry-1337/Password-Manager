using password_manager.tcp_modules.interfaces;

namespace password_manager.tcp_modules.modules
{
    public class pending : i_pending
    {
        public pending(byte[] contents, int size)
        {
            this.contents = contents;
            this.size = size;
        }

        public byte[] contents { get; set; }
        public int size { get; set; }
    }
}
