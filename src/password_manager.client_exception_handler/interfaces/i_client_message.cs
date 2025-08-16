using password_manager.client_message_handler.enums;

namespace password_manager.client_message_handler.interfaces
{
    internal interface i_client_message
    {
        public e_client_message_type client_message_type { get; set; }
        public string summary_info { get; set; }

        public abstract void prehandle(e_client_message_type client_message_type, string summary_info);
        public abstract void handle(string summary_info, out string label);
    }
}
