
namespace Lab2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.authors = new System.Windows.Forms.Button();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.formatLabel = new System.Windows.Forms.Label();
            this.radioButtonPDF = new System.Windows.Forms.RadioButton();
            this.radioButtonTXT = new System.Windows.Forms.RadioButton();
            this.radioButtonFB2 = new System.Windows.Forms.RadioButton();
            this.radioButtonEPUB = new System.Windows.Forms.RadioButton();
            this.bookSizeLabel = new System.Windows.Forms.Label();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.bookNameLabel = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxNumberOfPages = new System.Windows.Forms.TextBox();
            this.NumberOfPagesLabel = new System.Windows.Forms.Label();
            this.textBoxUDK = new System.Windows.Forms.TextBox();
            this.UDKLabel = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.checkBoxPay = new System.Windows.Forms.CheckBox();
            this.numericUpDownChapters = new System.Windows.Forms.NumericUpDown();
            this.SizeComboBox = new System.Windows.Forms.ComboBox();
            this.dataLabel = new System.Windows.Forms.Label();
            this.textBoxPublisher = new System.Windows.Forms.TextBox();
            this.publisherLabel = new System.Windows.Forms.Label();
            this.chaptersLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChapters)).BeginInit();
            this.SuspendLayout();
            // 
            // authors
            // 
            this.authors.BackColor = System.Drawing.Color.PeachPuff;
            this.authors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.authors.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.authors.FlatAppearance.BorderSize = 0;
            this.authors.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.authors.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authors.Location = new System.Drawing.Point(451, 350);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(140, 52);
            this.authors.TabIndex = 1;
            this.authors.Text = "Авторы";
            this.authors.UseVisualStyleBackColor = false;
            this.authors.Click += new System.EventHandler(this.authors_Click);
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.HorizontalScrollbar = true;
            this.listBoxInfo.ItemHeight = 20;
            this.listBoxInfo.Location = new System.Drawing.Point(34, 423);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.ScrollAlwaysVisible = true;
            this.listBoxInfo.Size = new System.Drawing.Size(557, 184);
            this.listBoxInfo.TabIndex = 2;
            // 
            // formatLabel
            // 
            this.formatLabel.AutoSize = true;
            this.formatLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formatLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.formatLabel.Location = new System.Drawing.Point(30, 223);
            this.formatLabel.Name = "formatLabel";
            this.formatLabel.Size = new System.Drawing.Size(84, 24);
            this.formatLabel.TabIndex = 3;
            this.formatLabel.Text = "Формат";
            // 
            // radioButtonPDF
            // 
            this.radioButtonPDF.AutoSize = true;
            this.radioButtonPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonPDF.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonPDF.Location = new System.Drawing.Point(34, 266);
            this.radioButtonPDF.Name = "radioButtonPDF";
            this.radioButtonPDF.Size = new System.Drawing.Size(63, 26);
            this.radioButtonPDF.TabIndex = 4;
            this.radioButtonPDF.TabStop = true;
            this.radioButtonPDF.Text = "PDF";
            this.radioButtonPDF.UseVisualStyleBackColor = true;
            // 
            // radioButtonTXT
            // 
            this.radioButtonTXT.AutoSize = true;
            this.radioButtonTXT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonTXT.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonTXT.Location = new System.Drawing.Point(34, 298);
            this.radioButtonTXT.Name = "radioButtonTXT";
            this.radioButtonTXT.Size = new System.Drawing.Size(62, 26);
            this.radioButtonTXT.TabIndex = 5;
            this.radioButtonTXT.TabStop = true;
            this.radioButtonTXT.Text = "TXT";
            this.radioButtonTXT.UseVisualStyleBackColor = true;
            // 
            // radioButtonFB2
            // 
            this.radioButtonFB2.AutoSize = true;
            this.radioButtonFB2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonFB2.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonFB2.Location = new System.Drawing.Point(34, 328);
            this.radioButtonFB2.Name = "radioButtonFB2";
            this.radioButtonFB2.Size = new System.Drawing.Size(59, 26);
            this.radioButtonFB2.TabIndex = 6;
            this.radioButtonFB2.TabStop = true;
            this.radioButtonFB2.Text = "FB2";
            this.radioButtonFB2.UseVisualStyleBackColor = true;
            // 
            // radioButtonEPUB
            // 
            this.radioButtonEPUB.AutoSize = true;
            this.radioButtonEPUB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonEPUB.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonEPUB.Location = new System.Drawing.Point(34, 360);
            this.radioButtonEPUB.Name = "radioButtonEPUB";
            this.radioButtonEPUB.Size = new System.Drawing.Size(74, 26);
            this.radioButtonEPUB.TabIndex = 7;
            this.radioButtonEPUB.TabStop = true;
            this.radioButtonEPUB.Text = "EPUB";
            this.radioButtonEPUB.UseVisualStyleBackColor = true;
            // 
            // bookSizeLabel
            // 
            this.bookSizeLabel.AutoSize = true;
            this.bookSizeLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bookSizeLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.bookSizeLabel.Location = new System.Drawing.Point(224, 223);
            this.bookSizeLabel.Name = "bookSizeLabel";
            this.bookSizeLabel.Size = new System.Drawing.Size(140, 24);
            this.bookSizeLabel.TabIndex = 8;
            this.bookSizeLabel.Text = "Размер книги";
            // 
            // textBoxSize
            // 
            this.textBoxSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSize.Location = new System.Drawing.Point(228, 266);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(80, 26);
            this.textBoxSize.TabIndex = 9;
            this.textBoxSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSize_KeyPress);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(34, 71);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(175, 26);
            this.textBoxName.TabIndex = 11;
            // 
            // bookNameLabel
            // 
            this.bookNameLabel.AutoSize = true;
            this.bookNameLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bookNameLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.bookNameLabel.Location = new System.Drawing.Point(30, 29);
            this.bookNameLabel.Name = "bookNameLabel";
            this.bookNameLabel.Size = new System.Drawing.Size(165, 24);
            this.bookNameLabel.TabIndex = 10;
            this.bookNameLabel.Text = "Название книги";
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLoad.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLoad.Location = new System.Drawing.Point(34, 614);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(131, 52);
            this.buttonLoad.TabIndex = 12;
            this.buttonLoad.Text = "Загрузить";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSave.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(316, 614);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(141, 52);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAdd.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(171, 614);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(137, 52);
            this.buttonAdd.TabIndex = 14;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxNumberOfPages
            // 
            this.textBoxNumberOfPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNumberOfPages.Location = new System.Drawing.Point(228, 350);
            this.textBoxNumberOfPages.Name = "textBoxNumberOfPages";
            this.textBoxNumberOfPages.Size = new System.Drawing.Size(175, 26);
            this.textBoxNumberOfPages.TabIndex = 18;
            this.textBoxNumberOfPages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumberOfPages_KeyPress);
            // 
            // NumberOfPagesLabel
            // 
            this.NumberOfPagesLabel.AutoSize = true;
            this.NumberOfPagesLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberOfPagesLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.NumberOfPagesLabel.Location = new System.Drawing.Point(224, 313);
            this.NumberOfPagesLabel.Name = "NumberOfPagesLabel";
            this.NumberOfPagesLabel.Size = new System.Drawing.Size(159, 24);
            this.NumberOfPagesLabel.TabIndex = 17;
            this.NumberOfPagesLabel.Text = "Кол-во страниц";
            // 
            // textBoxUDK
            // 
            this.textBoxUDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUDK.Location = new System.Drawing.Point(34, 156);
            this.textBoxUDK.Name = "textBoxUDK";
            this.textBoxUDK.Size = new System.Drawing.Size(100, 26);
            this.textBoxUDK.TabIndex = 16;
            this.textBoxUDK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUDK_KeyPress);
            // 
            // UDKLabel
            // 
            this.UDKLabel.AutoSize = true;
            this.UDKLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UDKLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.UDKLabel.Location = new System.Drawing.Point(30, 119);
            this.UDKLabel.Name = "UDKLabel";
            this.UDKLabel.Size = new System.Drawing.Size(120, 24);
            this.UDKLabel.TabIndex = 15;
            this.UDKLabel.Text = "УДК файла";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(228, 75);
            this.dateTimePicker.MaxDate = new System.DateTime(2024, 2, 16, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 20;
            this.dateTimePicker.Value = new System.DateTime(2024, 2, 16, 0, 0, 0, 0);
            // 
            // checkBoxPay
            // 
            this.checkBoxPay.AutoSize = true;
            this.checkBoxPay.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxPay.Location = new System.Drawing.Point(451, 317);
            this.checkBoxPay.Name = "checkBoxPay";
            this.checkBoxPay.Size = new System.Drawing.Size(103, 24);
            this.checkBoxPay.TabIndex = 21;
            this.checkBoxPay.Text = "Бесплатно";
            this.checkBoxPay.UseVisualStyleBackColor = true;
            // 
            // numericUpDownChapters
            // 
            this.numericUpDownChapters.Location = new System.Drawing.Point(451, 74);
            this.numericUpDownChapters.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownChapters.Name = "numericUpDownChapters";
            this.numericUpDownChapters.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownChapters.TabIndex = 22;
            // 
            // SizeComboBox
            // 
            this.SizeComboBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.SizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SizeComboBox.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeComboBox.FormattingEnabled = true;
            this.SizeComboBox.Items.AddRange(new object[] {
            "гб",
            "мб",
            "кб"});
            this.SizeComboBox.Location = new System.Drawing.Point(316, 266);
            this.SizeComboBox.Name = "SizeComboBox";
            this.SizeComboBox.Size = new System.Drawing.Size(48, 28);
            this.SizeComboBox.TabIndex = 23;
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.dataLabel.Location = new System.Drawing.Point(224, 31);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(139, 24);
            this.dataLabel.TabIndex = 24;
            this.dataLabel.Text = "Дата издания";
            // 
            // textBoxPublisher
            // 
            this.textBoxPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPublisher.Location = new System.Drawing.Point(228, 158);
            this.textBoxPublisher.Name = "textBoxPublisher";
            this.textBoxPublisher.Size = new System.Drawing.Size(200, 26);
            this.textBoxPublisher.TabIndex = 26;
            this.textBoxPublisher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPublisher_KeyPress);
            // 
            // publisherLabel
            // 
            this.publisherLabel.AutoSize = true;
            this.publisherLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publisherLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.publisherLabel.Location = new System.Drawing.Point(224, 121);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(137, 24);
            this.publisherLabel.TabIndex = 25;
            this.publisherLabel.Text = "Издательство";
            // 
            // chaptersLabel
            // 
            this.chaptersLabel.AutoSize = true;
            this.chaptersLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chaptersLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.chaptersLabel.Location = new System.Drawing.Point(447, 31);
            this.chaptersLabel.Name = "chaptersLabel";
            this.chaptersLabel.Size = new System.Drawing.Size(120, 24);
            this.chaptersLabel.TabIndex = 27;
            this.chaptersLabel.Text = "Кол-во глав";
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.PeachPuff;
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearButton.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(463, 614);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(128, 52);
            this.clearButton.TabIndex = 28;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(617, 687);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.chaptersLabel);
            this.Controls.Add(this.textBoxPublisher);
            this.Controls.Add(this.publisherLabel);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(this.SizeComboBox);
            this.Controls.Add(this.numericUpDownChapters);
            this.Controls.Add(this.checkBoxPay);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.textBoxNumberOfPages);
            this.Controls.Add(this.NumberOfPagesLabel);
            this.Controls.Add(this.textBoxUDK);
            this.Controls.Add(this.UDKLabel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.bookNameLabel);
            this.Controls.Add(this.textBoxSize);
            this.Controls.Add(this.bookSizeLabel);
            this.Controls.Add(this.radioButtonEPUB);
            this.Controls.Add(this.radioButtonFB2);
            this.Controls.Add(this.radioButtonTXT);
            this.Controls.Add(this.radioButtonPDF);
            this.Controls.Add(this.formatLabel);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.authors);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Electronic Library";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChapters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button authors;
        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.Label formatLabel;
        private System.Windows.Forms.RadioButton radioButtonPDF;
        private System.Windows.Forms.RadioButton radioButtonTXT;
        private System.Windows.Forms.RadioButton radioButtonFB2;
        private System.Windows.Forms.RadioButton radioButtonEPUB;
        private System.Windows.Forms.Label bookSizeLabel;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label bookNameLabel;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxNumberOfPages;
        private System.Windows.Forms.Label NumberOfPagesLabel;
        private System.Windows.Forms.TextBox textBoxUDK;
        private System.Windows.Forms.Label UDKLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.CheckBox checkBoxPay;
        private System.Windows.Forms.NumericUpDown numericUpDownChapters;
        private System.Windows.Forms.ComboBox SizeComboBox;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.TextBox textBoxPublisher;
        private System.Windows.Forms.Label publisherLabel;
        private System.Windows.Forms.Label chaptersLabel;
        private System.Windows.Forms.Button clearButton;
    }
}

