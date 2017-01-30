using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsBooks
{
    public interface IMessager 
    {
        void ShowMessage(string mssg);
        void ShowError(string mssg);
    }

    public class Messager: IMessager
    {
        public void ShowMessage(string mssg) 
        {
            MessageBox.Show(mssg, "Message");
        }

        public void ShowError(string mssg)
        {
            MessageBox.Show(mssg, "Error");
        }
    }
}
