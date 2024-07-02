
namespace Lab2
{
    partial class AuthorsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorsForm));
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.authorNameLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.buttonAddAuthor = new System.Windows.Forms.Button();
            this.authorsListLabel = new System.Windows.Forms.Label();
            this.listBoxAuthors = new System.Windows.Forms.ListBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(42, 56);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(267, 22);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            // 
            // authorNameLabel
            // 
            this.authorNameLabel.AutoSize = true;
            this.authorNameLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorNameLabel.Location = new System.Drawing.Point(37, 27);
            this.authorNameLabel.Name = "authorNameLabel";
            this.authorNameLabel.Size = new System.Drawing.Size(209, 24);
            this.authorNameLabel.TabIndex = 1;
            this.authorNameLabel.Text = "Введите ФИО автора";
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IDLabel.Location = new System.Drawing.Point(37, 81);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(113, 24);
            this.IDLabel.TabIndex = 3;
            this.IDLabel.Text = "Введите ID";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(42, 110);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(113, 22);
            this.textBoxID.TabIndex = 2;
            this.textBoxID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxID_KeyPress);
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countryLabel.Location = new System.Drawing.Point(37, 135);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(156, 24);
            this.countryLabel.TabIndex = 5;
            this.countryLabel.Text = "Введите страну";
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Location = new System.Drawing.Point(42, 164);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(196, 22);
            this.textBoxCountry.TabIndex = 4;
            this.textBoxCountry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCountry_KeyPress);
            // 
            // buttonAddAuthor
            // 
            this.buttonAddAuthor.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonAddAuthor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddAuthor.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddAuthor.Location = new System.Drawing.Point(37, 222);
            this.buttonAddAuthor.Name = "buttonAddAuthor";
            this.buttonAddAuthor.Size = new System.Drawing.Size(213, 62);
            this.buttonAddAuthor.TabIndex = 6;
            this.buttonAddAuthor.Text = "Добавить автора";
            this.buttonAddAuthor.UseVisualStyleBackColor = false;
            this.buttonAddAuthor.Click += new System.EventHandler(this.buttonAddAuthor_Click);
            // 
            // authorsListLabel
            // 
            this.authorsListLabel.AutoSize = true;
            this.authorsListLabel.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorsListLabel.Location = new System.Drawing.Point(458, 27);
            this.authorsListLabel.Name = "authorsListLabel";
            this.authorsListLabel.Size = new System.Drawing.Size(165, 24);
            this.authorsListLabel.TabIndex = 7;
            this.authorsListLabel.Text = "Список Авторов";
            // 
            // listBoxAuthors
            // 
            this.listBoxAuthors.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxAuthors.FormattingEnabled = true;
            this.listBoxAuthors.HorizontalScrollbar = true;
            this.listBoxAuthors.ItemHeight = 24;
            this.listBoxAuthors.Location = new System.Drawing.Point(350, 60);
            this.listBoxAuthors.Name = "listBoxAuthors";
            this.listBoxAuthors.ScrollAlwaysVisible = true;
            this.listBoxAuthors.Size = new System.Drawing.Size(386, 196);
            this.listBoxAuthors.TabIndex = 8;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonConfirm.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConfirm.Location = new System.Drawing.Point(205, 353);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(213, 62);
            this.buttonConfirm.TabIndex = 9;
            this.buttonConfirm.Text = "Подтвердить";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // AuthorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(758, 450);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.listBoxAuthors);
            this.Controls.Add(this.authorsListLabel);
            this.Controls.Add(this.buttonAddAuthor);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.authorNameLabel);
            this.Controls.Add(this.textBoxName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthorsForm";
            this.Text = "AuthorsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label authorNameLabel;
        private System.Windows.Forms.Label IDLabel;
        public System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label countryLabel;
        public System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.Button buttonAddAuthor;
        private System.Windows.Forms.Label authorsListLabel;
        public System.Windows.Forms.ListBox listBoxAuthors;
        private System.Windows.Forms.Button buttonConfirm;
    }
}