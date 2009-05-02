
using System;
using Gtk;

namespace Gui
{
    public partial class LoginDialog : Gtk.Dialog
    {
        // The Entry widgets for the username and login
        Entry usernameEntry = new Entry();
        Entry passwordEntry = new Entry();
        
        public LoginDialog()
        {
            // Set up basic look and feel.
            this.Title = "Please enter your login info";
            this.BorderWidth = 5;
            this.Resizable = false;
            
            // Now build the overall UI.
            BuildDialogUI();
        }

       // The read-only properties.
        public string UserName
            { get { return usernameEntry.Text; } }
        public string Password
            { get { return passwordEntry.Text; } }

        void BuildDialogUI()
        {
          // Add an HBox to the dialog's VBox.
          HBox hbox = new HBox (false, 8);
          hbox.BorderWidth = 8;
          this.VBox.PackStart (hbox, false, false, 0);
        
          // Add an Image widget to the HBox using a stock 'info' icon.
          Image stock = new Image (Stock.DialogInfo, IconSize.Dialog);
          hbox.PackStart (stock, false, false, 0);
        
          // Here we are using a Table to contain the other widgets.
          // Notice that the Table is added to the hBox.
          Table table = new Table (2, 2, false);
          table.RowSpacing = 4;
          table.ColumnSpacing = 4;
          hbox.PackStart (table, true, true, 0);
        
          Label label = new Label ("_Username");
          table.Attach (label, 0, 1, 0, 1);
          table.Attach (usernameEntry, 1, 2, 0, 1);
          label.MnemonicWidget = usernameEntry;
        
          label = new Label ("_Password");
          table.Attach (label, 0, 1, 1, 2);
          table.Attach (passwordEntry , 1, 2, 1, 2);
          label.MnemonicWidget = passwordEntry ;
          hbox.ShowAll ();

          // Add OK and Cancel Buttons.
          this.AddButton(Stock.Ok, ResponseType.Ok);
          this.AddButton(Stock.Cancel, ResponseType.Cancel);
        }
    }
}
