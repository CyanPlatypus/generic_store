using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsBooks
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BookStore<Book> bs = new BookStore<Book>();
            Controller<Book> controller = new Controller<Book>(bs, new Messager(), new StoreWindow<Book>(bs.StoreBooksBindingList, new NewBookWindow()));

            Application.Run((Form)controller.ControllerMainStoreWindow);
        }
    }
}
