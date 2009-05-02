using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Gtk;
using Wakame;

namespace Gui
{
    public delegate List<Transaction> getTransactions(string user, string pass, string accId);

    public class TransactionsList : ObservableTree , Wakame.IObserver
    {
        private ListStore store = null;

        public TransactionsList()
        {
            this.buildColumns();
        }

        public void addTransaction(Transaction transaction)
        {
            this.store.AppendValues(transaction.TransactionDate.ToShortDateString(),
                                    transaction.MerchantName,
                                    transaction.Amount.ToString());
        }

        private void buildColumns()
        {
            this.store = new ListStore(typeof (string),
                                       typeof (string),
                                       typeof (string));

            this.AppendColumn ("Date", new Gtk.CellRendererText (), "text", 0);
            this.AppendColumn ("Merchant", new Gtk.CellRendererText (), "text", 1);
            this.AppendColumn ("Amount", new Gtk.CellRendererText (), "text", 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">
        /// A <see cref="System.Object"/>
        /// </param>
        public void Notify(object id)
        {
            this.Model = null;
            this.store.Clear();

            getTransactions trList = delegate(string user, string pass, string accId)
            {
                List<Transaction> cachedRequest =
                    Wakame.TransactionListCacheManager.getCacheRequest(accId);

                if (cachedRequest == null)
                {
                    cachedRequest = wesabelib.wesabe_rest.getTransactions(user, pass, Int32.Parse(accId), null);
                    Wakame.TransactionListCacheManager.addCacheRequest(accId, cachedRequest);
                }
                return cachedRequest;
            };
            trList.BeginInvoke(Wakame.LoginManager.username, 
                               Wakame.LoginManager.password, 
                               (string)id, Callback, trList);

            this.Model = this.store;
            this.QueueDraw();
        }

        private void Callback(IAsyncResult r)
        {
            List<Transaction> tr = ((getTransactions)r.AsyncState).EndInvoke (r);

            foreach(Transaction t in tr)
                this.addTransaction(t);
        }
    }
}
