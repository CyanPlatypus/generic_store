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
    public interface IBookStoreWindow<T> 
    {
        BindingList<T> DGVStoreSource { get; set; }
        T EditingBook { get; set; }

        event EventHandler<ObjectEventArgs> OpenButtonClicked;
        event EventHandler<ObjectEventArgs> SaveButtonClicked;
        event EventHandler<ObjectEventArgs> HtmlReportButtonClicked;

        event EventHandler<ObjectEventArgs> DeleteButtonClicked;
        event EventHandler<ObjectEventArgs> AddButtonClicked;
        event EventHandler<ObjectEventArgs> EditButtonClicked;

        event EventHandler<ObjectEventArgs> ErrorOccurred;

    }

    public class StoreWindow<T> : Form, IBookStoreWindow<T>
    {
        public BindingList<T> DGVStoreSource { get; set; } //souce for DataGridView

        public T EditingBook { get; set; } // the Book that is being edited

        private NewItemWindow<T> AddBookDialogWindow; //window for ading and aditing Book 

        public event EventHandler<ObjectEventArgs> OpenButtonClicked;
        public event EventHandler<ObjectEventArgs> SaveButtonClicked;
        public event EventHandler<ObjectEventArgs> HtmlReportButtonClicked;

        public event EventHandler<ObjectEventArgs> DeleteButtonClicked;
        public event EventHandler<ObjectEventArgs> AddButtonClicked;
        public event EventHandler<ObjectEventArgs> EditButtonClicked;

        public event EventHandler<ObjectEventArgs> ErrorOccurred;

        private System.ComponentModel.IContainer components = null;

        private DataGridView storeDataGridView;
        private Button openButton;
        private Button saveButton;
        private Button deleteButton;
        private Button addButton;
        private Button reportButton;
        private Button editButton;

        public StoreWindow(BindingList<T> DGVSource, NewItemWindow<T> addBookDialogWindow)
        {
            DGVStoreSource = DGVSource;

            AddBookDialogWindow = addBookDialogWindow;

            InitializeComponent();

            storeDataGridView.DataSource = DGVStoreSource;
            storeDataGridView.AllowUserToAddRows = false;

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //looks for all selected rows and gives their number to controller, using ObjectEventArgs
            foreach (DataGridViewRow row in storeDataGridView.SelectedRows) 
            {
                if (row.Selected) 
                {
                    int index = row.Index;

                    if (DeleteButtonClicked != null)
                        DeleteButtonClicked(this, new ObjectEventArgs(index));
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //AddBookDialogWindow = new NewItemWindow<T>();
            AddBookDialogWindow.Create();

            AddBookDialogWindow.ErrorOccurred += AddBookDialogWindow_ErrorOccured;

            if (AddBookDialogWindow.ShowDialog(this) == DialogResult.OK)
            {
                //retrieves information about book from NewBookWindow
                T anotherBook = AddBookDialogWindow.DisplayedBook;

                //generates event, that tells that the instance of the Book was made 
                //and sends that instans in ObjectEventArgs
                if (AddButtonClicked != null)
                    AddButtonClicked(this, new ObjectEventArgs(anotherBook));
            }

            //AddBookDialogWindow.Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files|*.xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK) 
            {
                //generates event, that signalizes that user wants to open a file with name 
                if (SaveButtonClicked != null)
                    SaveButtonClicked(this, new ObjectEventArgs(saveFileDialog.FileName));
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter= "XML files|*.xml|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                if (OpenButtonClicked != null)
                    OpenButtonClicked(this, new ObjectEventArgs(openFileDialog.FileName));

                storeDataGridView.DataSource = DGVStoreSource;
            }
            
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML files|*.html";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (HtmlReportButtonClicked != null)
                    HtmlReportButtonClicked(this, new ObjectEventArgs(saveFileDialog.FileName));
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in storeDataGridView.SelectedRows)
            {
                if (row.Selected)
                {
                    int index = row.Index;
                    if (EditButtonClicked != null)
                    {
                        EditButtonClicked(this, new ObjectEventArgs(index));
                        break;
                    }
                }
            }

            if (EditingBook != null)
            {
                AddBookDialogWindow.Create(EditingBook);

                AddBookDialogWindow.ErrorOccurred += AddBookDialogWindow_ErrorOccured;

                if (AddBookDialogWindow.ShowDialog(this) == DialogResult.OK)
                {
                    DGVStoreSource.ResetBindings();
                }
                
                EditingBook = default(T);
            }
        }

        private void AddBookDialogWindow_ErrorOccured(object sender, ObjectEventArgs e) 
        {
            if (ErrorOccurred != null)
                ErrorOccurred(this, e);
        }

        private void InitializeComponent()
        {
            this.storeDataGridView = new System.Windows.Forms.DataGridView();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.storeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // storeDataGridView
            // 
            this.storeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.storeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.storeDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.storeDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.storeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storeDataGridView.Location = new System.Drawing.Point(12, 41);
            this.storeDataGridView.Name = "storeDataGridView";
            this.storeDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.storeDataGridView.Size = new System.Drawing.Size(498, 303);
            this.storeDataGridView.TabIndex = 0;
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.openButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.openButton.FlatAppearance.BorderSize = 0;
            this.openButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.openButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButton.Location = new System.Drawing.Point(12, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open XML";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(435, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save XML";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.BackColor = System.Drawing.Color.DarkGray;
            this.deleteButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.deleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(12, 350);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.BackColor = System.Drawing.Color.DarkGray;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Location = new System.Drawing.Point(93, 350);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // reportButton
            // 
            this.reportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reportButton.BackColor = System.Drawing.Color.Orange;
            this.reportButton.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.reportButton.FlatAppearance.BorderSize = 0;
            this.reportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.reportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru;
            this.reportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportButton.Location = new System.Drawing.Point(425, 350);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(85, 23);
            this.reportButton.TabIndex = 6;
            this.reportButton.Text = "HTML Report";
            this.reportButton.UseVisualStyleBackColor = false;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editButton.BackColor = System.Drawing.Color.DarkGray;
            this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.editButton.FlatAppearance.BorderSize = 0;
            this.editButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.editButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Location = new System.Drawing.Point(174, 350);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 5;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // StoreWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 385);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.storeDataGridView);
            this.Name = "StoreWindow";
            this.Text = "Book Store";
            ((System.ComponentModel.ISupportInitialize)(this.storeDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class ObjectEventArgs : EventArgs
    {
        public object Data { get; private set; }

        public ObjectEventArgs(object data)
        {
            this.Data = data;
        }
    }
}
