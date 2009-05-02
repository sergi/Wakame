namespace Wakame
{
	using System;
	using Gtk;

    public partial class MainWindow: Gtk.Window
    {    
        public MainWindow (): base (Gtk.WindowType.Toplevel)
        {
            Build ();
        }
    
        public HBox HSpace
        {
            get
            {
                return this.hbox1;
            }
        }
        
        protected void OnDeleteEvent (object sender, DeleteEventArgs a)
        {
            Application.Quit ();
            a.RetVal = true;
        }
		
		protected void OnOpen (object sender, EventArgs a)
        {
        }
    }
}