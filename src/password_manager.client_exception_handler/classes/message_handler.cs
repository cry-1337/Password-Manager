using password_manager.client_message_handler.enums;
using password_manager.client_message_handler.interfaces;

namespace password_manager.client_message_handler.classes
{
    public class message_handler : i_client_message_handler
    {
        private i_client_message message = new client_message();

        public void create_message(e_client_message_type message_type, string summary_info, out string info)
        {
            message.prehandle(message_type, summary_info);
            message.handle(summary_info, out info);
        }
    }
}
