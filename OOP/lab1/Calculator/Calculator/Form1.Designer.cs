namespace Calculator
{
    partial class Calculator
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.decBox = new System.Windows.Forms.TextBox();
            this.memory = new System.Windows.Forms.Label();
            this.examplePanel = new System.Windows.Forms.TextBox();
            this.andButton = new System.Windows.Forms.Button();
            this.orButton = new System.Windows.Forms.Button();
            this.xorButton = new System.Windows.Forms.Button();
            this.notButton = new System.Windows.Forms.Button();
            this.sevenButton = new System.Windows.Forms.Button();
            this.eightButton = new System.Windows.Forms.Button();
            this.nineButton = new System.Windows.Forms.Button();
            this.sixButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.fourButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.twoButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.zeroButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.equalButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.errorTick = new System.Windows.Forms.Timer(this.components);
            this.binBox = new System.Windows.Forms.TextBox();
            this.hexBox = new System.Windows.Forms.TextBox();
            this.octBox = new System.Windows.Forms.TextBox();
            this.displayPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayPanel
            // 
            this.displayPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.displayPanel.Controls.Add(this.octBox);
            this.displayPanel.Controls.Add(this.hexBox);
            this.displayPanel.Controls.Add(this.binBox);
            this.displayPanel.Controls.Add(this.decBox);
            this.displayPanel.Controls.Add(this.memory);
            this.displayPanel.Controls.Add(this.examplePanel);
            this.displayPanel.Location = new System.Drawing.Point(12, 12);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(416, 239);
            this.displayPanel.TabIndex = 0;
            // 
            // decBox
            // 
            this.decBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.decBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.decBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decBox.Location = new System.Drawing.Point(0, 83);
            this.decBox.Name = "decBox";
            this.decBox.ReadOnly = true;
            this.decBox.Size = new System.Drawing.Size(413, 21);
            this.decBox.TabIndex = 6;
            this.decBox.Text = "DEC ";
            // 
            // memory
            // 
            this.memory.AutoSize = true;
            this.memory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.memory.Location = new System.Drawing.Point(10, 51);
            this.memory.Name = "memory";
            this.memory.Size = new System.Drawing.Size(0, 20);
            this.memory.TabIndex = 5;
            // 
            // examplePanel
            // 
            this.examplePanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.examplePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.examplePanel.Location = new System.Drawing.Point(0, 0);
            this.examplePanel.Multiline = true;
            this.examplePanel.Name = "examplePanel";
            this.examplePanel.ReadOnly = true;
            this.examplePanel.Size = new System.Drawing.Size(413, 77);
            this.examplePanel.TabIndex = 0;
            // 
            // andButton
            // 
            this.andButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.andButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.andButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.andButton.Location = new System.Drawing.Point(12, 255);
            this.andButton.Name = "andButton";
            this.andButton.Size = new System.Drawing.Size(95, 50);
            this.andButton.TabIndex = 2;
            this.andButton.Text = "AND";
            this.andButton.UseVisualStyleBackColor = false;
            this.andButton.Click += new System.EventHandler(this.andButton_Click);
            // 
            // orButton
            // 
            this.orButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.orButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.orButton.Location = new System.Drawing.Point(119, 255);
            this.orButton.Name = "orButton";
            this.orButton.Size = new System.Drawing.Size(95, 50);
            this.orButton.TabIndex = 3;
            this.orButton.Text = "OR";
            this.orButton.UseVisualStyleBackColor = false;
            this.orButton.Click += new System.EventHandler(this.orButton_Click);
            // 
            // xorButton
            // 
            this.xorButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.xorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xorButton.Location = new System.Drawing.Point(226, 255);
            this.xorButton.Name = "xorButton";
            this.xorButton.Size = new System.Drawing.Size(95, 50);
            this.xorButton.TabIndex = 4;
            this.xorButton.Text = "XOR";
            this.xorButton.UseVisualStyleBackColor = false;
            this.xorButton.Click += new System.EventHandler(this.xorButton_Click);
            // 
            // notButton
            // 
            this.notButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.notButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notButton.Location = new System.Drawing.Point(333, 255);
            this.notButton.Name = "notButton";
            this.notButton.Size = new System.Drawing.Size(95, 50);
            this.notButton.TabIndex = 5;
            this.notButton.Text = "NOT";
            this.notButton.UseVisualStyleBackColor = false;
            this.notButton.Click += new System.EventHandler(this.notButton_Click);
            // 
            // sevenButton
            // 
            this.sevenButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sevenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sevenButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sevenButton.Location = new System.Drawing.Point(12, 314);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(95, 50);
            this.sevenButton.TabIndex = 6;
            this.sevenButton.Text = "7";
            this.sevenButton.UseVisualStyleBackColor = false;
            this.sevenButton.Click += new System.EventHandler(this.sevenButton_Click);
            // 
            // eightButton
            // 
            this.eightButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.eightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eightButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.eightButton.Location = new System.Drawing.Point(119, 313);
            this.eightButton.Name = "eightButton";
            this.eightButton.Size = new System.Drawing.Size(95, 50);
            this.eightButton.TabIndex = 7;
            this.eightButton.Text = "8";
            this.eightButton.UseVisualStyleBackColor = false;
            this.eightButton.Click += new System.EventHandler(this.eightButton_Click);
            // 
            // nineButton
            // 
            this.nineButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.nineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nineButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nineButton.Location = new System.Drawing.Point(226, 313);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(95, 50);
            this.nineButton.TabIndex = 8;
            this.nineButton.Text = "9";
            this.nineButton.UseVisualStyleBackColor = false;
            this.nineButton.Click += new System.EventHandler(this.nineButton_Click);
            // 
            // sixButton
            // 
            this.sixButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sixButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sixButton.Location = new System.Drawing.Point(226, 370);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(95, 50);
            this.sixButton.TabIndex = 11;
            this.sixButton.Text = "6";
            this.sixButton.UseVisualStyleBackColor = false;
            this.sixButton.Click += new System.EventHandler(this.sixButton_Click);
            // 
            // fiveButton
            // 
            this.fiveButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fiveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fiveButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fiveButton.Location = new System.Drawing.Point(118, 371);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(95, 50);
            this.fiveButton.TabIndex = 10;
            this.fiveButton.Text = "5";
            this.fiveButton.UseVisualStyleBackColor = false;
            this.fiveButton.Click += new System.EventHandler(this.fiveButton_Click);
            // 
            // fourButton
            // 
            this.fourButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fourButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fourButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fourButton.Location = new System.Drawing.Point(12, 371);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(95, 50);
            this.fourButton.TabIndex = 9;
            this.fourButton.Text = "4";
            this.fourButton.UseVisualStyleBackColor = false;
            this.fourButton.Click += new System.EventHandler(this.fourButton_Click);
            // 
            // threeButton
            // 
            this.threeButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.threeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.threeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.threeButton.Location = new System.Drawing.Point(226, 427);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(95, 50);
            this.threeButton.TabIndex = 14;
            this.threeButton.Text = "3";
            this.threeButton.UseVisualStyleBackColor = false;
            this.threeButton.Click += new System.EventHandler(this.threeButton_Click);
            // 
            // twoButton
            // 
            this.twoButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.twoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.twoButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.twoButton.Location = new System.Drawing.Point(119, 428);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(95, 50);
            this.twoButton.TabIndex = 13;
            this.twoButton.Text = "2";
            this.twoButton.UseVisualStyleBackColor = false;
            this.twoButton.Click += new System.EventHandler(this.twoButton_Click);
            // 
            // oneButton
            // 
            this.oneButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.oneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oneButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.oneButton.Location = new System.Drawing.Point(12, 428);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(95, 50);
            this.oneButton.TabIndex = 12;
            this.oneButton.Text = "1";
            this.oneButton.UseVisualStyleBackColor = false;
            this.oneButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // zeroButton
            // 
            this.zeroButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.zeroButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zeroButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.zeroButton.Location = new System.Drawing.Point(119, 484);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(95, 50);
            this.zeroButton.TabIndex = 15;
            this.zeroButton.Text = "0";
            this.zeroButton.UseVisualStyleBackColor = false;
            this.zeroButton.Click += new System.EventHandler(this.zeroButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearButton.Location = new System.Drawing.Point(333, 314);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(95, 50);
            this.clearButton.TabIndex = 16;
            this.clearButton.Text = "C";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // equalButton
            // 
            this.equalButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.equalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.equalButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.equalButton.Location = new System.Drawing.Point(333, 370);
            this.equalButton.Name = "equalButton";
            this.equalButton.Size = new System.Drawing.Size(95, 164);
            this.equalButton.TabIndex = 17;
            this.equalButton.Text = "=";
            this.equalButton.UseVisualStyleBackColor = false;
            this.equalButton.Click += new System.EventHandler(this.equalButton_Click);
            // 
            // minusButton
            // 
            this.minusButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.minusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minusButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.minusButton.Location = new System.Drawing.Point(226, 484);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(95, 50);
            this.minusButton.TabIndex = 18;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = false;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // errorTick
            // 
            this.errorTick.Tick += new System.EventHandler(this.errorTick_Tick);
            // 
            // binBox
            // 
            this.binBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.binBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.binBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.binBox.Location = new System.Drawing.Point(0, 119);
            this.binBox.Name = "binBox";
            this.binBox.ReadOnly = true;
            this.binBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.binBox.Size = new System.Drawing.Size(413, 21);
            this.binBox.TabIndex = 7;
            this.binBox.Text = "BIN ";
            this.binBox.WordWrap = false;
            // 
            // hexBox
            // 
            this.hexBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hexBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hexBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hexBox.Location = new System.Drawing.Point(0, 160);
            this.hexBox.Name = "hexBox";
            this.hexBox.ReadOnly = true;
            this.hexBox.Size = new System.Drawing.Size(413, 21);
            this.hexBox.TabIndex = 8;
            this.hexBox.Text = "HEX ";
            // 
            // octBox
            // 
            this.octBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.octBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.octBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.octBox.Location = new System.Drawing.Point(0, 199);
            this.octBox.Name = "octBox";
            this.octBox.ReadOnly = true;
            this.octBox.Size = new System.Drawing.Size(413, 21);
            this.octBox.TabIndex = 9;
            this.octBox.Text = "OCT  ";
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(438, 542);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.equalButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.zeroButton);
            this.Controls.Add(this.threeButton);
            this.Controls.Add(this.twoButton);
            this.Controls.Add(this.oneButton);
            this.Controls.Add(this.sixButton);
            this.Controls.Add(this.fiveButton);
            this.Controls.Add(this.fourButton);
            this.Controls.Add(this.nineButton);
            this.Controls.Add(this.eightButton);
            this.Controls.Add(this.sevenButton);
            this.Controls.Add(this.notButton);
            this.Controls.Add(this.xorButton);
            this.Controls.Add(this.orButton);
            this.Controls.Add(this.andButton);
            this.Controls.Add(this.displayPanel);
            this.Name = "Calculator";
            this.Text = "Binary Calculator";
            this.displayPanel.ResumeLayout(false);
            this.displayPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel displayPanel;
        private System.Windows.Forms.Button andButton;
        private System.Windows.Forms.TextBox examplePanel;
        private System.Windows.Forms.Button orButton;
        private System.Windows.Forms.Button xorButton;
        private System.Windows.Forms.Button notButton;
        private System.Windows.Forms.Button sevenButton;
        private System.Windows.Forms.Button eightButton;
        private System.Windows.Forms.Button nineButton;
        private System.Windows.Forms.Button sixButton;
        private System.Windows.Forms.Button fiveButton;
        private System.Windows.Forms.Button fourButton;
        private System.Windows.Forms.Button threeButton;
        private System.Windows.Forms.Button twoButton;
        private System.Windows.Forms.Button oneButton;
        private System.Windows.Forms.Button zeroButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button equalButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Label memory;
        private System.Windows.Forms.Timer errorTick;
        private System.Windows.Forms.TextBox decBox;
        private System.Windows.Forms.TextBox binBox;
        private System.Windows.Forms.TextBox octBox;
        private System.Windows.Forms.TextBox hexBox;
    }
}

