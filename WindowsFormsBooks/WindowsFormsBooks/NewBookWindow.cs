using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsBooks
{
    public partial class NewBookWindow : NewItemWindow<Book>
    {

        private static readonly Color errorColor = Color.LightCoral;
        private static readonly Color noErrorColor = Color.White;

        private static readonly Color minusBackColor = Color.Silver;//LightCoral
        private static readonly Color minusMouseDownBackColor = Color.Gray;
        private static readonly Color minusMouseOverBackColor = Color.DarkGray;


        private static readonly Color enabledBackColor = Color.DarkGray;
        private static readonly Color disabledBackColor = Color.LightGray;

        private static readonly Color enabledForeColor = Color.Black;
        private static readonly Color disabledForeColor = Color.WhiteSmoke;

        new public event EventHandler<ObjectEventArgs> ErrorOccurred;

        public NewBookWindow() 
        {
            //InitializeComponent();
        }

        public override void Create() 
        {
            Create(null);
        }

        public override void Create(Book book)
        {
            this.Controls.Clear();
            InitializeComponent();

            DisplayedBook = book;
            PlaceControls();

            addButton.Enabled = false;
        }

        private  void PlaceControls()
        {
            if (DisplayedBook != null)
            {
                titleTextBox.Text = DisplayedBook.Title;
                languageTextBox.Text = DisplayedBook.Language;
                categoryTextBox.Text = DisplayedBook.Category;
                yearTextBox.Text = Convert.ToString(DisplayedBook.Year);
                priceTextBox.Text = Convert.ToString(DisplayedBook.Price);
                coverTextBox.Text = DisplayedBook.Cover;
                authorTextBox.Text = DisplayedBook.Authors[0];

                for (int i = 1; i < DisplayedBook.Authors.Count; i++) 
                {
                    AddTextbox(DisplayedBook.Authors[i]);
                }

                titleLabel.Text = "Edit Book";
                addButton.Text = "Edit";
            }

            titleTextBox.TextChanged += new EventHandler(titleTextBox_TextChanged);
            languageTextBox.TextChanged += new EventHandler(languageTextBox_TextChanged);
            categoryTextBox.TextChanged += new EventHandler(categoryTextBox_TextChanged);
            yearTextBox.TextChanged += new EventHandler(yearTextBox_TextChanged);
            priceTextBox.TextChanged += new EventHandler(priceTextBox_TextChanged);
            coverTextBox.TextChanged += new EventHandler(coverTextBox_TextChanged);
            authorTextBox.TextChanged += authorTextBox_TextChanged;
        }

        void authorTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextCangeHandle(Book.OkForAuthor, (TextBox)sender);
        }

        void coverTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextCangeHandle(Book.OkForCover, (TextBox)sender);
        }

        void priceTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextCangeHandle(Book.OkForPrice, (TextBox)sender);
        }

        void yearTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextCangeHandle(Book.OkForYear, (TextBox)sender);
        }

        void categoryTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextCangeHandle(Book.OkForCategory, (TextBox)sender);
        }

        void languageTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextCangeHandle(Book.OkForLanguage, (TextBox)sender);
        }

        void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextCangeHandle(Book.OkForTitle, (TextBox)sender);
        }

        private void TextBoxTextCangeHandle(Func<string,bool> Criterion, TextBox tB)
        {
            if (!Criterion(tB.Text))
                tB.BackColor = errorColor;
            else
                tB.BackColor = noErrorColor;
            
            CheckAllTextBoxes();
        }

        private void AddTextbox(string text) 
        {
            //text box for author
            TextBox tB = new TextBox()
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("MicrosoftSansSerif", 10),
                Height = 19,
                Width = 190,
                Text = text
            };

            tB.TextChanged += authorTextBox_TextChanged;

            //delete author textBox  button
            Button b = new Button() 
            {
                Height = 16, Width =16,
                FlatStyle = FlatStyle.Flat,
                BackColor = minusBackColor,
                Text = "X",
                Font = new Font("MicrosoftSansSerif", 5)
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseDownBackColor = minusMouseDownBackColor;
            b.FlatAppearance.MouseOverBackColor = minusMouseOverBackColor;

            b.Click += minusButton_Click;

            //place controls
            tBoxflowLayoutPanel.Controls.Add(tB);
            minusBFlowLayoutPanel.Controls.Add(b);
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            int index= minusBFlowLayoutPanel.Controls.IndexOf((Button)sender);

            //delete minus button and author textbox
            minusBFlowLayoutPanel.Controls.RemoveAt(index);
            tBoxflowLayoutPanel.Controls.RemoveAt((index+1));

            CheckAllTextBoxes();
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            AddTextbox(string.Empty);
            CheckAllTextBoxes();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            List<string> authors = GetherAuthors();

            if (DisplayedBook != null)
            {
                try
                {
                    DisplayedBook.Edit(titleTextBox.Text, languageTextBox.Text,
                        authors, categoryTextBox.Text, Convert.ToInt32(yearTextBox.Text),
                        Convert.ToDouble(priceTextBox.Text), coverTextBox.Text);
                }
                catch (Exception ex)
                {
                    if (ErrorOccurred != null)
                        ErrorOccurred(this, new ObjectEventArgs("Invalid field value."));
                }
            }
            else
                try
                {
                    DisplayedBook = new Book(titleTextBox.Text, languageTextBox.Text,
                    authors, categoryTextBox.Text, Convert.ToInt32(yearTextBox.Text),
                    Convert.ToDouble(priceTextBox.Text), coverTextBox.Text);
                }
                catch (Exception ex)
                {
                    if (ErrorOccurred != null)
                        ErrorOccurred(this, new ObjectEventArgs("Invalid field value."));
                }

        }

        private void addButton_EnabledChanged(object sender, EventArgs e)
        {
            if (((Button)sender).Enabled == true)
            {
                ((Button)sender).BackColor = enabledBackColor;
                ((Button)sender).ForeColor = enabledForeColor;
            }
            else
            {
                ((Button)sender).BackColor = disabledBackColor;
                ((Button)sender).ForeColor = disabledForeColor;
            }
        }

        private void CheckAllTextBoxes() 
        {
            if (Book.OkForCategory(categoryTextBox.Text) &&
                Book.OkForCover(coverTextBox.Text) &&
                Book.OkForLanguage(languageTextBox.Text) &&
                Book.OkForPrice(priceTextBox.Text) &&
                Book.OkForTitle(titleTextBox.Text) &&
                Book.OkForYear(yearTextBox.Text) && CheckAllAuthorTextBoxes())
                addButton.Enabled = true;
            else
                addButton.Enabled = false;
        }

        private bool CheckAllAuthorTextBoxes() 
        {
            foreach (var tB in tBoxflowLayoutPanel.Controls) 
            {
                if (tB is TextBox) 
                {
                    if (!Book.OkForAuthor(((TextBox)tB).Text))
                        return false;
                }
            }
            return true;
        }

        private List<string> GetherAuthors() 
        {
            List<string> l = new List<string>();
            foreach (var tB in tBoxflowLayoutPanel.Controls) 
            {
                l.Add(((TextBox)tB).Text);
            }

            return l;
        }
    }

    public abstract class NewItemWindow<T> : Form 
    {
        public T DisplayedBook { get; protected set; }

        public event EventHandler<ObjectEventArgs> ErrorOccurred;

        public NewItemWindow(){ }
        public NewItemWindow(T item){}
        public abstract void Create(T item);
        public abstract void Create();

    }
}
