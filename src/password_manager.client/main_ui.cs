using password_manager.client_message_handler.interfaces;
using password_manager.client_message_handler.classes;
using password_manager.client_message_handler.enums;
using System.Net.Sockets;
using System.Text;

namespace password_manager
{
    public partial class main_ui : Form
    {
        private static i_client_message_handler message_handler = new message_handler();
        private static char[] forbidden_symbols = [' ', '/', '\\', '\"'];
        private const int port = 21013;

        public main_ui()
        {
            InitializeComponent();
        }

        private void handle_empty_error()
        {
            message_handler.create_message(e_client_message_type.error, "Login or Password is empty", out string label);
            label1.Visible = true;
            label1.Text = label;
        }

        private bool have_forbidden_symbols(string str)
        {
            foreach (var symbol in forbidden_symbols)
                if (str.Contains(symbol)) return true;
            return false;
        }

        private void send_auth_msg(string login, string password)
        {
            string request = $"{login} {password}";

            Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp)
            {
                SendBufferSize = 65535,
                ReceiveBufferSize = 65535,
                NoDelay = true,
            };

            socket.Connect("127.0.0.1", port);
            socket.Send(Encoding.UTF8.GetBytes(request));
        }

        private void register_button_clicked(object sender, EventArgs e)
        {
            if (username.Text == string.Empty || password.Text == string.Empty)
            {
                handle_empty_error();
                return;
            }

            if (have_forbidden_symbols(username.Text))
            {
                message_handler.create_message(
                    e_client_message_type.error,
                    $"You have forbidden symbol in username. Forbidden symbols: {string.Join(", ", forbidden_symbols.Select(c => $"\"{c}\""))}",
                    out string label
                );
                label1.Visible = true;
                label1.Text = label;
                return;
            }

            if (have_forbidden_symbols(password.Text))
            {
                message_handler.create_message(
                    e_client_message_type.error,
                    $"You have forbidden symbol in password. Forbidden symbols: {string.Join(", ", forbidden_symbols.Select(c => $"\"{c}\""))}",
                    out string label
                );
                label1.Visible = true;
                label1.Text = label;
                return;
            }

            send_auth_msg(username.Text, password.Text);
        }

        private void login_button_clicked(object sender, EventArgs e)
        {
            if (username.Text == string.Empty || password.Text == string.Empty)
            {
                handle_empty_error();
                return;
            }

            if (have_forbidden_symbols(username.Text))
            {
                message_handler.create_message(
                    e_client_message_type.error,
                    $"You have forbidden symbol in username. Forbidden symbols: {string.Join(", ", forbidden_symbols.Select(c => $"\"{c}\""))}",
                    out string label
                );
                label1.Visible = true;
                label1.Text = label;
                return;
            }

            if (have_forbidden_symbols(password.Text))
            {
                message_handler.create_message(
                    e_client_message_type.error,
                    $"You have forbidden symbol in password. Forbidden symbols: {string.Join(", ", forbidden_symbols.Select(c => $"\"{c}\""))}",
                    out string label
                );
                label1.Visible = true;
                label1.Text = label;
                return;
            }

            send_auth_msg(username.Text, password.Text);
        }
    }
}
