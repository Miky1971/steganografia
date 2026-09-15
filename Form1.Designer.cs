namespace steganografia
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button_FileFrom = new Button();
            label_FileFrom = new Label();
            textBox_FileFrom = new TextBox();
            pictureBox_FileFrom = new PictureBox();
            textBox_FileTo = new TextBox();
            label_FileTo = new Label();
            button_FileTo = new Button();
            textBox_Pass = new TextBox();
            label_Pass = new Label();
            button_Pass = new Button();
            checkBox_Encrypt = new CheckBox();
            textBox_Text = new TextBox();
            label_Text = new Label();
            button_WriteText = new Button();
            button_ReadText = new Button();
            openFileDialog_FileFrom = new OpenFileDialog();
            saveFileDialog_FileTo = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox_FileFrom).BeginInit();
            SuspendLayout();
            // 
            // button_FileFrom
            // 
            button_FileFrom.Location = new Point(481, 11);
            button_FileFrom.Name = "button_FileFrom";
            button_FileFrom.Size = new Size(29, 23);
            button_FileFrom.TabIndex = 0;
            button_FileFrom.Text = "...";
            button_FileFrom.UseVisualStyleBackColor = true;
            button_FileFrom.Click += button_FileFrom_Click;
            // 
            // label_FileFrom
            // 
            label_FileFrom.AutoSize = true;
            label_FileFrom.Location = new Point(34, 15);
            label_FileFrom.Name = "label_FileFrom";
            label_FileFrom.Size = new Size(53, 15);
            label_FileFrom.TabIndex = 1;
            label_FileFrom.Text = "Obrazek:";
            // 
            // textBox_FileFrom
            // 
            textBox_FileFrom.Location = new Point(93, 11);
            textBox_FileFrom.Name = "textBox_FileFrom";
            textBox_FileFrom.Size = new Size(391, 23);
            textBox_FileFrom.TabIndex = 2;
            textBox_FileFrom.Leave += textBox_FileFrom_Leave;
            // 
            // pictureBox_FileFrom
            // 
            pictureBox_FileFrom.Location = new Point(531, 11);
            pictureBox_FileFrom.Name = "pictureBox_FileFrom";
            pictureBox_FileFrom.Size = new Size(655, 342);
            pictureBox_FileFrom.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_FileFrom.TabIndex = 3;
            pictureBox_FileFrom.TabStop = false;
            // 
            // textBox_FileTo
            // 
            textBox_FileTo.Location = new Point(93, 37);
            textBox_FileTo.Name = "textBox_FileTo";
            textBox_FileTo.Size = new Size(391, 23);
            textBox_FileTo.TabIndex = 6;
            // 
            // label_FileTo
            // 
            label_FileTo.AutoSize = true;
            label_FileTo.Location = new Point(2, 41);
            label_FileTo.Name = "label_FileTo";
            label_FileTo.Size = new Size(85, 15);
            label_FileTo.TabIndex = 5;
            label_FileTo.Text = "Plik wynikowy:";
            // 
            // button_FileTo
            // 
            button_FileTo.Location = new Point(481, 37);
            button_FileTo.Name = "button_FileTo";
            button_FileTo.Size = new Size(29, 23);
            button_FileTo.TabIndex = 4;
            button_FileTo.Text = "...";
            button_FileTo.UseVisualStyleBackColor = true;
            button_FileTo.Click += button_FileTo_Click;
            // 
            // textBox_Pass
            // 
            textBox_Pass.Location = new Point(93, 290);
            textBox_Pass.Name = "textBox_Pass";
            textBox_Pass.Size = new Size(391, 23);
            textBox_Pass.TabIndex = 9;
            // 
            // label_Pass
            // 
            label_Pass.AutoSize = true;
            label_Pass.Location = new Point(47, 294);
            label_Pass.Name = "label_Pass";
            label_Pass.Size = new Size(40, 15);
            label_Pass.TabIndex = 8;
            label_Pass.Text = "Hasło:";
            // 
            // button_Pass
            // 
            button_Pass.Location = new Point(481, 290);
            button_Pass.Name = "button_Pass";
            button_Pass.Size = new Size(29, 23);
            button_Pass.TabIndex = 7;
            button_Pass.Text = "👁";
            button_Pass.UseVisualStyleBackColor = true;
            button_Pass.Click += button_Pass_Click;
            // 
            // checkBox_Encrypt
            // 
            checkBox_Encrypt.AutoSize = true;
            checkBox_Encrypt.Location = new Point(93, 265);
            checkBox_Encrypt.Name = "checkBox_Encrypt";
            checkBox_Encrypt.Size = new Size(119, 19);
            checkBox_Encrypt.TabIndex = 10;
            checkBox_Encrypt.Text = "Tekst szyfrowany?";
            checkBox_Encrypt.UseVisualStyleBackColor = true;
            checkBox_Encrypt.CheckedChanged += checkBox_Encrypt_CheckedChanged;
            // 
            // textBox_Text
            // 
            textBox_Text.Location = new Point(93, 66);
            textBox_Text.Multiline = true;
            textBox_Text.Name = "textBox_Text";
            textBox_Text.ScrollBars = ScrollBars.Vertical;
            textBox_Text.Size = new Size(417, 193);
            textBox_Text.TabIndex = 11;
            // 
            // label_Text
            // 
            label_Text.AutoSize = true;
            label_Text.Location = new Point(34, 79);
            label_Text.Name = "label_Text";
            label_Text.Size = new Size(36, 15);
            label_Text.TabIndex = 12;
            label_Text.Text = "Tekst:";
            // 
            // button_WriteText
            // 
            button_WriteText.Location = new Point(96, 330);
            button_WriteText.Name = "button_WriteText";
            button_WriteText.Size = new Size(125, 23);
            button_WriteText.TabIndex = 13;
            button_WriteText.Text = "Zapisz tekst";
            button_WriteText.UseVisualStyleBackColor = true;
            button_WriteText.Click += button_WriteText_Click;
            // 
            // button_ReadText
            // 
            button_ReadText.Location = new Point(374, 331);
            button_ReadText.Name = "button_ReadText";
            button_ReadText.Size = new Size(136, 23);
            button_ReadText.TabIndex = 14;
            button_ReadText.Text = "Odczytaj tekst";
            button_ReadText.UseVisualStyleBackColor = true;
            button_ReadText.Click += button_ReadText_Click;
            // 
            // openFileDialog_FileFrom
            // 
            openFileDialog_FileFrom.FileName = "openFileDialog1";
            openFileDialog_FileFrom.Filter = "\"Pliki obrazów|*.png;*.bmp;*.jpg;*.jpeg\"";
            // 
            // saveFileDialog_FileTo
            // 
            saveFileDialog_FileTo.Filter = "\"Pliki obrazów|*.png;*.bmp\"";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 362);
            Controls.Add(button_ReadText);
            Controls.Add(button_WriteText);
            Controls.Add(label_Text);
            Controls.Add(textBox_Text);
            Controls.Add(checkBox_Encrypt);
            Controls.Add(textBox_Pass);
            Controls.Add(label_Pass);
            Controls.Add(button_Pass);
            Controls.Add(textBox_FileTo);
            Controls.Add(label_FileTo);
            Controls.Add(button_FileTo);
            Controls.Add(pictureBox_FileFrom);
            Controls.Add(textBox_FileFrom);
            Controls.Add(label_FileFrom);
            Controls.Add(button_FileFrom);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Steganografia";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_FileFrom).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_FileFrom;
        private Label label_FileFrom;
        private TextBox textBox_FileFrom;
        private PictureBox pictureBox_FileFrom;
        private TextBox textBox_FileTo;
        private Label label_FileTo;
        private Button button_FileTo;
        private TextBox textBox_Pass;
        private Label label_Pass;
        private Button button_Pass;
        private CheckBox checkBox_Encrypt;
        private TextBox textBox_Text;
        private Label label_Text;
        private Button button_WriteText;
        private Button button_ReadText;
        private OpenFileDialog openFileDialog_FileFrom;
        private SaveFileDialog saveFileDialog_FileTo;
    }
}
