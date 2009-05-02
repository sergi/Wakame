// Main.cs created with MonoDevelop
// User: sergi at 4:02 PM 11/26/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using Gtk;
using wesabelib;
using Gui;

namespace Wakame
{
    public class WakameApp
    {
        public static void Main (string[] args)
        {
            new WakameApp(args);
        }
        
        public WakameApp (string[] args)
        {
            Application.Init ();
            MainWindow win = new MainWindow ();
            win.Show ();

            Accounts response = null;
            AccountList AccountTree = null;
            TransactionsList TransactionsTree = new TransactionsList();

            response = wesabelib.wesabe_rest.getAccounts(LoginManager.username, LoginManager.password);
            if (response != null)
                AccountTree = new AccountList(response);
            else
                AccountTree = new AccountList();

            AccountTree.Register(TransactionsTree);

            win.HSpace.Add(AccountTree);
            win.HSpace.Add(TransactionsTree);
            //Wakame.REST.Rest.getAccounts(LoginManager.username, LoginManager.password);
            win.ShowAll();
            Application.Run();
        }
    }
}