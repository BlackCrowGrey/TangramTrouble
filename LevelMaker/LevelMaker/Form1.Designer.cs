namespace LevelMaker
{
    partial class Form1
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
            this.shapeCheckBox = new System.Windows.Forms.CheckedListBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.previewLabel = new System.Windows.Forms.Label();
            this.previewBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.instructionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shapeCheckBox
            // 
            this.shapeCheckBox.FormattingEnabled = true;
            this.shapeCheckBox.Items.AddRange(new object[] {
            "Square(Large)",
            "Square(Small)",
            "Triangle(Large)",
            "Triangle(Medium)",
            "Triangle(Small)",
            "Parallelogram",
            "Rectangle(Short)",
            "Rectangle(Medium)",
            "Rectangle(Long)",
            "L-Block",
            "J-Block",
            "T-Block",
            "S-Block",
            "Z-Block"});
            this.shapeCheckBox.Location = new System.Drawing.Point(12, 100);
            this.shapeCheckBox.Name = "shapeCheckBox";
            this.shapeCheckBox.Size = new System.Drawing.Size(194, 214);
            this.shapeCheckBox.TabIndex = 0;
            this.shapeCheckBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.shapeCheckBox_ItemCheck);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(12, 337);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(194, 48);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(12, 44);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(95, 20);
            this.heightBox.TabIndex = 3;
            this.heightBox.TextChanged += new System.EventHandler(this.heightBox_TextChanged);
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(111, 44);
            this.widthBox.MaxLength = 3200;
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(95, 20);
            this.widthBox.TabIndex = 5;
            this.widthBox.TextChanged += new System.EventHandler(this.widthBox_TextChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.Location = new System.Drawing.Point(111, 28);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(95, 13);
            this.widthLabel.TabIndex = 4;
            this.widthLabel.Text = "Width";
            this.widthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // heightLabel
            // 
            this.heightLabel.Location = new System.Drawing.Point(12, 28);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(95, 13);
            this.heightLabel.TabIndex = 6;
            this.heightLabel.Text = "Height";
            this.heightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewLabel
            // 
            this.previewLabel.Location = new System.Drawing.Point(215, 68);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(264, 21);
            this.previewLabel.TabIndex = 8;
            this.previewLabel.Text = "Preview";
            this.previewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(218, 100);
            this.previewBox.Multiline = true;
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(261, 214);
            this.previewBox.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(491, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // instructionsMenu
            // 
            this.instructionsMenu.Name = "instructionsMenu";
            this.instructionsMenu.Size = new System.Drawing.Size(81, 20);
            this.instructionsMenu.Text = "Instructions";
            this.instructionsMenu.Click += new System.EventHandler(this.instructionsMenu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 404);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.shapeCheckBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Level Maker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox shapeCheckBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.TextBox previewBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem instructionsMenu;
    }
}

