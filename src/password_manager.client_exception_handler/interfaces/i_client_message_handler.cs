using password_manager.client_message_handler.enums;

namespace password_manager.client_message_handler.interfaces
{
    public interface i_client_message_handler
    {
        public abstract void create_message(e_client_message_type message_type, string summary_info, out string info);
    }
}
