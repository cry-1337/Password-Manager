using password_manager.client_message_handler.enums;
using password_manager.client_message_handler.interfaces;
using System.Text;

namespace password_manager.client_message_handler.classes
{
    // issue: for right code-style i can't use IDisposable

    internal class client_message : i_client_message
    {
        public e_client_message_type client_message_type { get; set; }
        public string summary_info { get; set; }

        public client_message(e_client_message_type client_message_type, string summary_info)
        {
            this.client_message_type = client_message_type;
            this.summary_info = summary_info;
        }

        public client_message() => summary_info = "unhandled";

        public void prehandle(e_client_message_type client_message_type, string summary_info)
        {
            this.client_message_type = client_message_type;
            this.summary_info = summary_info;
        }

        void i_client_message.handle(string summary_info, out string label)
        {
            StringBuilder response_builder = new StringBuilder();

            try
            {
                switch (client_message_type)
                {
                    case e_client_message_type.error:
                        response_builder.Append("Error: ");
                        break;
                    case e_client_message_type.warning:
                        response_builder.Append("Warning: ");
                        break;
                    case e_client_message_type.info:
                        response_builder.Append("Info: ");
                        break;
                    default:
                        response_builder.Append("Info: ");
                        break;
                }

                response_builder.Append(summary_info);
            }
            catch (NullReferenceException nex)
            {
                response_builder.Append("didn't precached client message. main info: ");
                response_builder.Append(nex);
            }
            catch (Exception ex)
            {
                response_builder.Append("unhandled exception. main info: ");
                response_builder.Append(ex);
            }
            finally
            {
                label = response_builder.ToString();
                dispose();
            }
        }

        // bruh garbage collector
        public void dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
