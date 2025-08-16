using password_manager.tcp_modules.interfaces;

namespace password_manager.server.managers
{
    public class netid_manager : i_netid_manager
    {
        private int last_id = 0;

        public int free_id()
        {
            if (last_id + 1 == int.MaxValue)
                last_id = 0;

            int return_id = last_id;
            last_id++;
            return return_id;
        }
    }
}
