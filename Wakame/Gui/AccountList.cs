using System;
using System.Collections;
using Gtk;

namespace Gui
{
    public class AccountList : ObservableTree
    {
        private ListStore accountList;

        public AccountList()
        {
            this.buildColumns();
        }

        public AccountList(Accounts accounts)
        {
            this.accountList = new ListStore(typeof(string), typeof(string));
            this.buildColumns();
            this.addAccounts(accounts);

            this.Model = this.accountList;
            this.Selection.Changed += OnSelectionChanged;
        }

        public void addAccounts(Accounts accounts)
        {
            foreach (Account account in accounts.Items)
                this.accountList.AppendValues(account.ID.ToString(), account.name);
        }

        private void buildColumns()
        {
            this.AppendColumn ("Id", new Gtk.CellRendererText (), "text", 0);
            this.AppendColumn ("Account", new Gtk.CellRendererText (), "text", 1);
        }

        #region "Events"
        private void OnSelectionChanged (object o, EventArgs args)
        {
            TreeIter iter;
            TreeModel model;
            TreeSelection selection = o as TreeSelection;

            if (selection.GetSelected (out model, out iter))
            {
                this.NotifyObservers((string) model.GetValue(iter, 0));
            }
        }
        #endregion
    }
}
