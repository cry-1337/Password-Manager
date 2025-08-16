namespace password_manager
{
    internal static class main
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new main_ui());
        }
    }
}