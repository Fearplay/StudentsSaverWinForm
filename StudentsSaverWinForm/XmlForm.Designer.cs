namespace StudentsSaverWinForm
{
    partial class XmlForm
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
            this.createSaveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.vysledekView = new System.Windows.Forms.DataGridView();
            this.jmenoTextBox = new System.Windows.Forms.TextBox();
            this.prijmeniTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vekTextBox = new System.Windows.Forms.TextBox();
            this.oborTextBox = new System.Windows.Forms.TextBox();
            this.nazevTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vysledekView)).BeginInit();
            this.SuspendLayout();
            // 
            // createSaveButton
            // 
            this.createSaveButton.Location = new System.Drawing.Point(613, 72);
            this.createSaveButton.Name = "createSaveButton";
            this.createSaveButton.Size = new System.Drawing.Size(107, 23);
            this.createSaveButton.TabIndex = 6;
            this.createSaveButton.Text = "Create/Save File";
            this.createSaveButton.UseVisualStyleBackColor = true;
            this.createSaveButton.Click += new System.EventHandler(this.createSaveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(613, 124);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(107, 23);
            this.loadButton.TabIndex = 7;
            this.loadButton.Text = "Load File";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // vysledekView
            // 
            this.vysledekView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vysledekView.Location = new System.Drawing.Point(12, 302);
            this.vysledekView.Name = "vysledekView";
            this.vysledekView.Size = new System.Drawing.Size(776, 136);
            this.vysledekView.TabIndex = 0;
            this.vysledekView.TabStop = false;
            // 
            // jmenoTextBox
            // 
            this.jmenoTextBox.Location = new System.Drawing.Point(96, 96);
            this.jmenoTextBox.Name = "jmenoTextBox";
            this.jmenoTextBox.ShortcutsEnabled = false;
            this.jmenoTextBox.Size = new System.Drawing.Size(168, 20);
            this.jmenoTextBox.TabIndex = 2;
            this.jmenoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.jmenoTextBox_KeyPress);
            // 
            // prijmeniTextBox
            // 
            this.prijmeniTextBox.Location = new System.Drawing.Point(96, 146);
            this.prijmeniTextBox.Name = "prijmeniTextBox";
            this.prijmeniTextBox.ShortcutsEnabled = false;
            this.prijmeniTextBox.Size = new System.Drawing.Size(168, 20);
            this.prijmeniTextBox.TabIndex = 3;
            this.prijmeniTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.prijmeniTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Jméno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Příjmení";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Věk";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Obor";
            // 
            // vekTextBox
            // 
            this.vekTextBox.Location = new System.Drawing.Point(96, 196);
            this.vekTextBox.Name = "vekTextBox";
            this.vekTextBox.ShortcutsEnabled = false;
            this.vekTextBox.Size = new System.Drawing.Size(168, 20);
            this.vekTextBox.TabIndex = 4;
            this.vekTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vekTextBox_KeyPress);
            // 
            // oborTextBox
            // 
            this.oborTextBox.Location = new System.Drawing.Point(96, 246);
            this.oborTextBox.Name = "oborTextBox";
            this.oborTextBox.ShortcutsEnabled = false;
            this.oborTextBox.Size = new System.Drawing.Size(168, 20);
            this.oborTextBox.TabIndex = 5;
            this.oborTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.oborTextBox_KeyPress);
            // 
            // nazevTextBox
            // 
            this.nazevTextBox.Location = new System.Drawing.Point(96, 46);
            this.nazevTextBox.Name = "nazevTextBox";
            this.nazevTextBox.ShortcutsEnabled = false;
            this.nazevTextBox.Size = new System.Drawing.Size(168, 20);
            this.nazevTextBox.TabIndex = 1;
            this.nazevTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nazevTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Název souboru";
            // 
            // menuButton
            // 
            this.menuButton.Location = new System.Drawing.Point(613, 173);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(107, 23);
            this.menuButton.TabIndex = 8;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // XmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nazevTextBox);
            this.Controls.Add(this.oborTextBox);
            this.Controls.Add(this.vekTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prijmeniTextBox);
            this.Controls.Add(this.jmenoTextBox);
            this.Controls.Add(this.vysledekView);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.createSaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XmlForm";
            this.Text = "XmlSaver";
            ((System.ComponentModel.ISupportInitialize)(this.vysledekView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createSaveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.DataGridView vysledekView;
        private System.Windows.Forms.TextBox jmenoTextBox;
        private System.Windows.Forms.TextBox prijmeniTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox vekTextBox;
        private System.Windows.Forms.TextBox oborTextBox;
        private System.Windows.Forms.TextBox nazevTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button menuButton;
    }
}

