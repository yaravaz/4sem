
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
            this.buttonSave = new System.Windows.Forms.Button();
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ByNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byPublisherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ByYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ByPageAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BySelectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameSortToolStripMenuIte = new System.Windows.Forms.ToolStripMenuItem();
            this.YearSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PageAmountSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveSortedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.UpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.DownToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ClearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.HideToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.showToolPanelButton = new System.Windows.Forms.Button();
            this.ObjectCountLabel = new System.Windows.Forms.Label();
            this.LastMoveLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChapters)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // authors
            // 
            this.authors.BackColor = System.Drawing.Color.PeachPuff;
            this.authors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.authors.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.authors.FlatAppearance.BorderSize = 0;
            this.authors.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.authors.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authors.Location = new System.Drawing.Point(235, 357);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(115, 52);
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
            this.listBoxInfo.Location = new System.Drawing.Point(18, 45);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.ScrollAlwaysVisible = true;
            this.listBoxInfo.Size = new System.Drawing.Size(206, 364);
            this.listBoxInfo.TabIndex = 2;
            // 
            // formatLabel
            // 
            this.formatLabel.AutoSize = true;
            this.formatLabel.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formatLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.formatLabel.Location = new System.Drawing.Point(466, 240);
            this.formatLabel.Name = "formatLabel";
            this.formatLabel.Size = new System.Drawing.Size(76, 22);
            this.formatLabel.TabIndex = 3;
            this.formatLabel.Text = "Формат";
            // 
            // radioButtonPDF
            // 
            this.radioButtonPDF.AutoSize = true;
            this.radioButtonPDF.Checked = true;
            this.radioButtonPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonPDF.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonPDF.Location = new System.Drawing.Point(467, 267);
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
            this.radioButtonTXT.Location = new System.Drawing.Point(468, 312);
            this.radioButtonTXT.Name = "radioButtonTXT";
            this.radioButtonTXT.Size = new System.Drawing.Size(62, 26);
            this.radioButtonTXT.TabIndex = 5;
            this.radioButtonTXT.Text = "TXT";
            this.radioButtonTXT.UseVisualStyleBackColor = true;
            // 
            // radioButtonFB2
            // 
            this.radioButtonFB2.AutoSize = true;
            this.radioButtonFB2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonFB2.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonFB2.Location = new System.Drawing.Point(536, 267);
            this.radioButtonFB2.Name = "radioButtonFB2";
            this.radioButtonFB2.Size = new System.Drawing.Size(59, 26);
            this.radioButtonFB2.TabIndex = 6;
            this.radioButtonFB2.Text = "FB2";
            this.radioButtonFB2.UseVisualStyleBackColor = true;
            // 
            // radioButtonEPUB
            // 
            this.radioButtonEPUB.AutoSize = true;
            this.radioButtonEPUB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonEPUB.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonEPUB.Location = new System.Drawing.Point(536, 313);
            this.radioButtonEPUB.Name = "radioButtonEPUB";
            this.radioButtonEPUB.Size = new System.Drawing.Size(74, 26);
            this.radioButtonEPUB.TabIndex = 7;
            this.radioButtonEPUB.Text = "EPUB";
            this.radioButtonEPUB.UseVisualStyleBackColor = true;
            // 
            // bookSizeLabel
            // 
            this.bookSizeLabel.AutoSize = true;
            this.bookSizeLabel.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bookSizeLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.bookSizeLabel.Location = new System.Drawing.Point(244, 172);
            this.bookSizeLabel.Name = "bookSizeLabel";
            this.bookSizeLabel.Size = new System.Drawing.Size(125, 22);
            this.bookSizeLabel.TabIndex = 8;
            this.bookSizeLabel.Text = "Размер книги";
            // 
            // textBoxSize
            // 
            this.textBoxSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSize.Location = new System.Drawing.Point(248, 199);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(115, 26);
            this.textBoxSize.TabIndex = 9;
            this.textBoxSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSize_KeyPress);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(247, 72);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(175, 26);
            this.textBoxName.TabIndex = 11;
            // 
            // bookNameLabel
            // 
            this.bookNameLabel.AutoSize = true;
            this.bookNameLabel.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bookNameLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.bookNameLabel.Location = new System.Drawing.Point(243, 45);
            this.bookNameLabel.Name = "bookNameLabel";
            this.bookNameLabel.Size = new System.Drawing.Size(146, 22);
            this.bookNameLabel.TabIndex = 10;
            this.bookNameLabel.Text = "Название книги";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSave.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(380, 357);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(115, 53);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxNumberOfPages
            // 
            this.textBoxNumberOfPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNumberOfPages.Location = new System.Drawing.Point(248, 267);
            this.textBoxNumberOfPages.Name = "textBoxNumberOfPages";
            this.textBoxNumberOfPages.Size = new System.Drawing.Size(175, 26);
            this.textBoxNumberOfPages.TabIndex = 18;
            this.textBoxNumberOfPages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumberOfPages_KeyPress);
            // 
            // NumberOfPagesLabel
            // 
            this.NumberOfPagesLabel.AutoSize = true;
            this.NumberOfPagesLabel.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberOfPagesLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.NumberOfPagesLabel.Location = new System.Drawing.Point(244, 240);
            this.NumberOfPagesLabel.Name = "NumberOfPagesLabel";
            this.NumberOfPagesLabel.Size = new System.Drawing.Size(143, 22);
            this.NumberOfPagesLabel.TabIndex = 17;
            this.NumberOfPagesLabel.Text = "Кол-во страниц";
            // 
            // textBoxUDK
            // 
            this.textBoxUDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUDK.Location = new System.Drawing.Point(247, 133);
            this.textBoxUDK.Name = "textBoxUDK";
            this.textBoxUDK.Size = new System.Drawing.Size(83, 26);
            this.textBoxUDK.TabIndex = 16;
            this.textBoxUDK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUDK_KeyPress);
            // 
            // UDKLabel
            // 
            this.UDKLabel.AutoSize = true;
            this.UDKLabel.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UDKLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.UDKLabel.Location = new System.Drawing.Point(243, 108);
            this.UDKLabel.Name = "UDKLabel";
            this.UDKLabel.Size = new System.Drawing.Size(50, 22);
            this.UDKLabel.TabIndex = 15;
            this.UDKLabel.Text = "УДК";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(470, 135);
            this.dateTimePicker.MaxDate = new System.DateTime(2024, 2, 16, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(175, 22);
            this.dateTimePicker.TabIndex = 20;
            this.dateTimePicker.Value = new System.DateTime(2024, 2, 16, 0, 0, 0, 0);
            // 
            // checkBoxPay
            // 
            this.checkBoxPay.AutoSize = true;
            this.checkBoxPay.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxPay.Location = new System.Drawing.Point(248, 314);
            this.checkBoxPay.Name = "checkBoxPay";
            this.checkBoxPay.Size = new System.Drawing.Size(120, 26);
            this.checkBoxPay.TabIndex = 21;
            this.checkBoxPay.Text = "Бесплатно";
            this.checkBoxPay.UseVisualStyleBackColor = true;
            // 
            // numericUpDownChapters
            // 
            this.numericUpDownChapters.Location = new System.Drawing.Point(470, 199);
            this.numericUpDownChapters.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownChapters.Name = "numericUpDownChapters";
            this.numericUpDownChapters.Size = new System.Drawing.Size(175, 22);
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
            this.SizeComboBox.Location = new System.Drawing.Point(374, 199);
            this.SizeComboBox.Name = "SizeComboBox";
            this.SizeComboBox.Size = new System.Drawing.Size(48, 28);
            this.SizeComboBox.TabIndex = 23;
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.dataLabel.Location = new System.Drawing.Point(466, 108);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(124, 22);
            this.dataLabel.TabIndex = 24;
            this.dataLabel.Text = "Дата издания";
            // 
            // textBoxPublisher
            // 
            this.textBoxPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPublisher.Location = new System.Drawing.Point(470, 72);
            this.textBoxPublisher.Name = "textBoxPublisher";
            this.textBoxPublisher.Size = new System.Drawing.Size(175, 26);
            this.textBoxPublisher.TabIndex = 26;
            this.textBoxPublisher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPublisher_KeyPress);
            // 
            // publisherLabel
            // 
            this.publisherLabel.AutoSize = true;
            this.publisherLabel.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publisherLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.publisherLabel.Location = new System.Drawing.Point(466, 45);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(124, 22);
            this.publisherLabel.TabIndex = 25;
            this.publisherLabel.Text = "Издательство";
            // 
            // chaptersLabel
            // 
            this.chaptersLabel.AutoSize = true;
            this.chaptersLabel.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chaptersLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.chaptersLabel.Location = new System.Drawing.Point(466, 172);
            this.chaptersLabel.Name = "chaptersLabel";
            this.chaptersLabel.Size = new System.Drawing.Size(109, 22);
            this.chaptersLabel.TabIndex = 27;
            this.chaptersLabel.Text = "Кол-во глав";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.AntiqueWhite;
            this.menuStrip.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem,
            this.сортироватьToolStripMenuItem,
            this.SaveSortedToolStripMenuItem,
            this.InfoAboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(680, 30);
            this.menuStrip.TabIndex = 29;
            this.menuStrip.Text = "menuStrip1";
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ByNameToolStripMenuItem,
            this.byPublisherToolStripMenuItem,
            this.ByYearToolStripMenuItem,
            this.ByPageAmountToolStripMenuItem,
            this.BySelectorsToolStripMenuItem});
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
            this.поискToolStripMenuItem.Text = "Поиск";
            // 
            // ByNameToolStripMenuItem
            // 
            this.ByNameToolStripMenuItem.Name = "ByNameToolStripMenuItem";
            this.ByNameToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.ByNameToolStripMenuItem.Text = "По названию";
            this.ByNameToolStripMenuItem.Click += new System.EventHandler(this.ByNameToolStripMenuItem_Click);
            // 
            // byPublisherToolStripMenuItem
            // 
            this.byPublisherToolStripMenuItem.Name = "byPublisherToolStripMenuItem";
            this.byPublisherToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.byPublisherToolStripMenuItem.Text = "По издательству";
            this.byPublisherToolStripMenuItem.Click += new System.EventHandler(this.byPublisherToolStripMenuItem_Click);
            // 
            // ByYearToolStripMenuItem
            // 
            this.ByYearToolStripMenuItem.Name = "ByYearToolStripMenuItem";
            this.ByYearToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.ByYearToolStripMenuItem.Text = "По году";
            this.ByYearToolStripMenuItem.Click += new System.EventHandler(this.ByYearToolStripMenuItem_Click);
            // 
            // ByPageAmountToolStripMenuItem
            // 
            this.ByPageAmountToolStripMenuItem.Name = "ByPageAmountToolStripMenuItem";
            this.ByPageAmountToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.ByPageAmountToolStripMenuItem.Text = "По количеству страниц";
            this.ByPageAmountToolStripMenuItem.Click += new System.EventHandler(this.ByPageAmountToolStripMenuItem_Click);
            // 
            // BySelectorsToolStripMenuItem
            // 
            this.BySelectorsToolStripMenuItem.Name = "BySelectorsToolStripMenuItem";
            this.BySelectorsToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.BySelectorsToolStripMenuItem.Text = "Конструктор";
            this.BySelectorsToolStripMenuItem.Click += new System.EventHandler(this.BySelectorsToolStripMenuItem_Click);
            // 
            // сортироватьToolStripMenuItem
            // 
            this.сортироватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NameSortToolStripMenuIte,
            this.YearSortToolStripMenuItem,
            this.PageAmountSortToolStripMenuItem});
            this.сортироватьToolStripMenuItem.Name = "сортироватьToolStripMenuItem";
            this.сортироватьToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.сортироватьToolStripMenuItem.Text = "Сортировка по";
            // 
            // NameSortToolStripMenuIte
            // 
            this.NameSortToolStripMenuIte.Name = "NameSortToolStripMenuIte";
            this.NameSortToolStripMenuIte.Size = new System.Drawing.Size(259, 26);
            this.NameSortToolStripMenuIte.Text = "Названию";
            this.NameSortToolStripMenuIte.Click += new System.EventHandler(this.NameSortToolStripMenuIte_Click);
            // 
            // YearSortToolStripMenuItem
            // 
            this.YearSortToolStripMenuItem.Name = "YearSortToolStripMenuItem";
            this.YearSortToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.YearSortToolStripMenuItem.Text = "Году издания";
            this.YearSortToolStripMenuItem.Click += new System.EventHandler(this.YearSortToolStripMenuItem_Click);
            // 
            // PageAmountSortToolStripMenuItem
            // 
            this.PageAmountSortToolStripMenuItem.Name = "PageAmountSortToolStripMenuItem";
            this.PageAmountSortToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.PageAmountSortToolStripMenuItem.Text = "Количеству страниц";
            this.PageAmountSortToolStripMenuItem.Click += new System.EventHandler(this.PageAmountSortToolStripMenuItem_Click);
            // 
            // SaveSortedToolStripMenuItem
            // 
            this.SaveSortedToolStripMenuItem.Name = "SaveSortedToolStripMenuItem";
            this.SaveSortedToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.SaveSortedToolStripMenuItem.Text = "Сохранить результаты поиска";
            this.SaveSortedToolStripMenuItem.Click += new System.EventHandler(this.SaveSortedToolStripMenuItem_Click);
            // 
            // InfoAboutToolStripMenuItem
            // 
            this.InfoAboutToolStripMenuItem.Name = "InfoAboutToolStripMenuItem";
            this.InfoAboutToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.InfoAboutToolStripMenuItem.Text = "О программе";
            this.InfoAboutToolStripMenuItem.Click += new System.EventHandler(this.InfoAboutToolStripMenuItem_Click);
            // 
            // textBoxYear
            // 
            this.textBoxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxYear.Location = new System.Drawing.Point(336, 133);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(86, 26);
            this.textBoxYear.TabIndex = 31;
            this.textBoxYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxYear_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(332, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 22);
            this.label1.TabIndex = 30;
            this.label1.Text = "Год:";
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.AntiqueWhite;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpToolStripButton,
            this.DownToolStripButton,
            this.ClearToolStripButton,
            this.DeleteToolStripButton,
            this.HideToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 456);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(680, 27);
            this.toolStrip.TabIndex = 32;
            this.toolStrip.Text = "toolStrip1";
            // 
            // UpToolStripButton
            // 
            this.UpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpToolStripButton.Name = "UpToolStripButton";
            this.UpToolStripButton.Size = new System.Drawing.Size(64, 24);
            this.UpToolStripButton.Text = "Вперёд";
            this.UpToolStripButton.Click += new System.EventHandler(this.UpToolStripButton_Click);
            // 
            // DownToolStripButton
            // 
            this.DownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DownToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DownToolStripButton.Image")));
            this.DownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownToolStripButton.Name = "DownToolStripButton";
            this.DownToolStripButton.Size = new System.Drawing.Size(55, 24);
            this.DownToolStripButton.Text = "Назад";
            this.DownToolStripButton.Click += new System.EventHandler(this.DownToolStripButton_Click);
            // 
            // ClearToolStripButton
            // 
            this.ClearToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ClearToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearToolStripButton.Image")));
            this.ClearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearToolStripButton.Name = "ClearToolStripButton";
            this.ClearToolStripButton.Size = new System.Drawing.Size(77, 24);
            this.ClearToolStripButton.Text = "Очистить";
            this.ClearToolStripButton.Click += new System.EventHandler(this.ClearToolStripButton_Click);
            // 
            // DeleteToolStripButton
            // 
            this.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripButton.Image")));
            this.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolStripButton.Name = "DeleteToolStripButton";
            this.DeleteToolStripButton.Size = new System.Drawing.Size(69, 24);
            this.DeleteToolStripButton.Text = "Удалить";
            this.DeleteToolStripButton.Click += new System.EventHandler(this.DeleteToolStripButton_Click);
            // 
            // HideToolStripButton
            // 
            this.HideToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HideToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("HideToolStripButton.Image")));
            this.HideToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HideToolStripButton.Name = "HideToolStripButton";
            this.HideToolStripButton.Size = new System.Drawing.Size(63, 24);
            this.HideToolStripButton.Text = "Скрыть";
            this.HideToolStripButton.Click += new System.EventHandler(this.HideToolStripButton_Click);
            // 
            // showToolPanelButton
            // 
            this.showToolPanelButton.BackColor = System.Drawing.Color.PeachPuff;
            this.showToolPanelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showToolPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showToolPanelButton.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showToolPanelButton.Location = new System.Drawing.Point(528, 356);
            this.showToolPanelButton.Name = "showToolPanelButton";
            this.showToolPanelButton.Size = new System.Drawing.Size(117, 53);
            this.showToolPanelButton.TabIndex = 33;
            this.showToolPanelButton.Text = "Развернуть";
            this.showToolPanelButton.UseVisualStyleBackColor = false;
            this.showToolPanelButton.Visible = false;
            this.showToolPanelButton.Click += new System.EventHandler(this.showToolPanelButton_Click);
            // 
            // ObjectCountLabel
            // 
            this.ObjectCountLabel.AutoSize = true;
            this.ObjectCountLabel.Font = new System.Drawing.Font("Book Antiqua", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ObjectCountLabel.Location = new System.Drawing.Point(15, 425);
            this.ObjectCountLabel.Name = "ObjectCountLabel";
            this.ObjectCountLabel.Size = new System.Drawing.Size(139, 17);
            this.ObjectCountLabel.TabIndex = 34;
            this.ObjectCountLabel.Text = "Количество объектов: ";
            // 
            // LastMoveLabel
            // 
            this.LastMoveLabel.AutoSize = true;
            this.LastMoveLabel.Font = new System.Drawing.Font("Book Antiqua", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastMoveLabel.Location = new System.Drawing.Point(196, 425);
            this.LastMoveLabel.Name = "LastMoveLabel";
            this.LastMoveLabel.Size = new System.Drawing.Size(134, 17);
            this.LastMoveLabel.TabIndex = 35;
            this.LastMoveLabel.Text = "Последнее действие: ";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Book Antiqua", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeLabel.Location = new System.Drawing.Point(525, 425);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(0, 17);
            this.TimeLabel.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(680, 483);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.LastMoveLabel);
            this.Controls.Add(this.ObjectCountLabel);
            this.Controls.Add(this.showToolPanelButton);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.label1);
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
            this.Controls.Add(this.buttonSave);
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
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Electronic Library";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChapters)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
        private System.Windows.Forms.Button buttonSave;
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
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ByNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byPublisherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ByYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ByPageAmountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BySelectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameSortToolStripMenuIte;
        private System.Windows.Forms.ToolStripMenuItem YearSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PageAmountSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveSortedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InfoAboutToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton UpToolStripButton;
        private System.Windows.Forms.ToolStripButton DownToolStripButton;
        private System.Windows.Forms.ToolStripButton ClearToolStripButton;
        private System.Windows.Forms.ToolStripButton DeleteToolStripButton;
        private System.Windows.Forms.ToolStripButton HideToolStripButton;
        private System.Windows.Forms.Button showToolPanelButton;
        private System.Windows.Forms.Label ObjectCountLabel;
        private System.Windows.Forms.Label LastMoveLabel;
        private System.Windows.Forms.Label TimeLabel;
    }
}

