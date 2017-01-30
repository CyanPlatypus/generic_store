namespace WindowsFormsBooks
{
    partial class NewBookWindow
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.tBoxflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.languageTextBox = new System.Windows.Forms.TextBox();
            this.coverTextBox = new System.Windows.Forms.TextBox();
            this.plusButton = new System.Windows.Forms.Button();
            this.languageLabel = new System.Windows.Forms.Label();
            this.coverLabel = new System.Windows.Forms.Label();
            this.minusBFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tBoxflowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.DarkGray;
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.ForeColor = System.Drawing.Color.Black;
            this.addButton.Location = new System.Drawing.Point(37, 231);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.EnabledChanged += new System.EventHandler(this.addButton_EnabledChanged);
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.DarkGray;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(205, 231);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.categoryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.categoryTextBox.Location = new System.Drawing.Point(80, 94);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(190, 16);
            this.categoryTextBox.TabIndex = 3;
            // 
            // yearTextBox
            // 
            this.yearTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yearTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.yearTextBox.Location = new System.Drawing.Point(80, 116);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(190, 16);
            this.yearTextBox.TabIndex = 4;
            // 
            // authorTextBox
            // 
            this.authorTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.authorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.authorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.authorTextBox.Location = new System.Drawing.Point(3, 3);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(190, 16);
            this.authorTextBox.TabIndex = 8;
            // 
            // titleTextBox
            // 
            this.titleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.titleTextBox.Location = new System.Drawing.Point(80, 50);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(190, 16);
            this.titleTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Author";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Category";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(18, 118);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(29, 13);
            this.yearLabel.TabIndex = 9;
            this.yearLabel.Text = "Year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Price";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.titleLabel.Location = new System.Drawing.Point(251, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(112, 20);
            this.titleLabel.TabIndex = 11;
            this.titleLabel.Text = "Add new Book";
            // 
            // priceTextBox
            // 
            this.priceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.priceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.priceTextBox.Location = new System.Drawing.Point(80, 138);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(190, 16);
            this.priceTextBox.TabIndex = 5;
            // 
            // tBoxflowLayoutPanel
            // 
            this.tBoxflowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tBoxflowLayoutPanel.Controls.Add(this.authorTextBox);
            this.tBoxflowLayoutPanel.Location = new System.Drawing.Point(359, 47);
            this.tBoxflowLayoutPanel.Name = "tBoxflowLayoutPanel";
            this.tBoxflowLayoutPanel.Size = new System.Drawing.Size(199, 220);
            this.tBoxflowLayoutPanel.TabIndex = 7;
            // 
            // languageTextBox
            // 
            this.languageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.languageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.languageTextBox.Location = new System.Drawing.Point(80, 72);
            this.languageTextBox.Name = "languageTextBox";
            this.languageTextBox.Size = new System.Drawing.Size(190, 16);
            this.languageTextBox.TabIndex = 2;
            // 
            // coverTextBox
            // 
            this.coverTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.coverTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.coverTextBox.Location = new System.Drawing.Point(80, 160);
            this.coverTextBox.Name = "coverTextBox";
            this.coverTextBox.Size = new System.Drawing.Size(190, 16);
            this.coverTextBox.TabIndex = 6;
            // 
            // plusButton
            // 
            this.plusButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.plusButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.plusButton.FlatAppearance.BorderSize = 0;
            this.plusButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.plusButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.plusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plusButton.Location = new System.Drawing.Point(324, 76);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(23, 23);
            this.plusButton.TabIndex = 9;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = false;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(16, 74);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(55, 13);
            this.languageLabel.TabIndex = 16;
            this.languageLabel.Text = "Language";
            // 
            // coverLabel
            // 
            this.coverLabel.AutoSize = true;
            this.coverLabel.Location = new System.Drawing.Point(18, 162);
            this.coverLabel.Name = "coverLabel";
            this.coverLabel.Size = new System.Drawing.Size(35, 13);
            this.coverLabel.TabIndex = 17;
            this.coverLabel.Text = "Cover";
            // 
            // minusBFlowLayoutPanel
            // 
            this.minusBFlowLayoutPanel.Location = new System.Drawing.Point(563, 69);
            this.minusBFlowLayoutPanel.Name = "minusBFlowLayoutPanel";
            this.minusBFlowLayoutPanel.Size = new System.Drawing.Size(24, 199);
            this.minusBFlowLayoutPanel.TabIndex = 18;
            // 
            // NewBookWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 266);
            this.Controls.Add(this.minusBFlowLayoutPanel);
            this.Controls.Add(this.coverLabel);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.coverTextBox);
            this.Controls.Add(this.languageTextBox);
            this.Controls.Add(this.tBoxflowLayoutPanel);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Name = "NewBookWindow";
            this.Text = "Book";
            this.tBoxflowLayoutPanel.ResumeLayout(false);
            this.tBoxflowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.FlowLayoutPanel tBoxflowLayoutPanel;
        private System.Windows.Forms.TextBox languageTextBox;
        private System.Windows.Forms.TextBox coverTextBox;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label coverLabel;
        private System.Windows.Forms.FlowLayoutPanel minusBFlowLayoutPanel;
    }
}