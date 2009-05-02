
using System;
using Gtk;

namespace Wakame
{
    public static class LoginManager
    {
        private static string _username = null;
        private static string _password = null;
        
        public static string username
        {
            get 
            {
                if (_username == null)
                    showDialog();

                return _username;
            }
        }

        public static string password
        {
            get 
            {
                if (_password == null)
                    showDialog();

                return _password;
            }
        }

        private static void showDialog()
        {
            Gui.LoginDialog ld = new Gui.LoginDialog();
            ResponseType rsp = (ResponseType)ld.Run();
                    
            if(rsp == ResponseType.Ok)
            {
                _username = ld.UserName;
                _password = ld.Password;
            }

            ld.Destroy();
        }
    }
}
