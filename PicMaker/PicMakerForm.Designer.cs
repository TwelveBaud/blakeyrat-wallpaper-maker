namespace PicMaker
{
    partial class PicMakerForm
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
			this.components = new System.ComponentModel.Container();
			this.ResultsBox = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.GenerateButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.SaveABunchButton = new System.Windows.Forms.Button();
			this.XSizeField = new System.Windows.Forms.TextBox();
			this.YSizeField = new System.Windows.Forms.TextBox();
			this.NumberToSaveField = new System.Windows.Forms.TextBox();
			this.ThreadWatcher = new System.Windows.Forms.Timer(this.components);
			this.DateToSaveField = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.LastSeedLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ResultsBox)).BeginInit();
			this.SuspendLayout();
			// 
			// ResultsBox
			// 
			this.ResultsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ResultsBox.BackColor = System.Drawing.Color.Transparent;
			this.ResultsBox.Location = new System.Drawing.Point(13, 37);
			this.ResultsBox.Name = "ResultsBox";
			this.ResultsBox.Size = new System.Drawing.Size(1159, 513);
			this.ResultsBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.ResultsBox.TabIndex = 0;
			this.ResultsBox.TabStop = false;
			this.ResultsBox.Click += new System.EventHandler(this.ResultsBox_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Image Size:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(147, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "x";
			// 
			// GenerateButton
			// 
			this.GenerateButton.Location = new System.Drawing.Point(231, 8);
			this.GenerateButton.Name = "GenerateButton";
			this.GenerateButton.Size = new System.Drawing.Size(75, 23);
			this.GenerateButton.TabIndex = 5;
			this.GenerateButton.Text = "Generate";
			this.GenerateButton.UseVisualStyleBackColor = true;
			this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(312, 8);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 6;
			this.SaveButton.Text = "Save...";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// SaveABunchButton
			// 
			this.SaveABunchButton.Location = new System.Drawing.Point(393, 8);
			this.SaveABunchButton.Name = "SaveABunchButton";
			this.SaveABunchButton.Size = new System.Drawing.Size(150, 23);
			this.SaveABunchButton.TabIndex = 7;
			this.SaveABunchButton.Text = "Save A Bunch...";
			this.SaveABunchButton.UseVisualStyleBackColor = true;
			this.SaveABunchButton.Click += new System.EventHandler(this.SaveABunchButton_Click);
			// 
			// XSizeField
			// 
			this.XSizeField.Location = new System.Drawing.Point(81, 10);
			this.XSizeField.Name = "XSizeField";
			this.XSizeField.Size = new System.Drawing.Size(60, 20);
			this.XSizeField.TabIndex = 11;
			this.XSizeField.Text = "3840";
			// 
			// YSizeField
			// 
			this.YSizeField.Location = new System.Drawing.Point(165, 10);
			this.YSizeField.Name = "YSizeField";
			this.YSizeField.Size = new System.Drawing.Size(60, 20);
			this.YSizeField.TabIndex = 12;
			this.YSizeField.Text = "2160";
			// 
			// NumberToSaveField
			// 
			this.NumberToSaveField.Location = new System.Drawing.Point(549, 10);
			this.NumberToSaveField.Name = "NumberToSaveField";
			this.NumberToSaveField.Size = new System.Drawing.Size(100, 20);
			this.NumberToSaveField.TabIndex = 13;
			this.NumberToSaveField.Text = "10";
			// 
			// ThreadWatcher
			// 
			this.ThreadWatcher.Tick += new System.EventHandler(this.ThreadWatcher_Tick);
			// 
			// DateToSaveField
			// 
			this.DateToSaveField.Location = new System.Drawing.Point(655, 10);
			this.DateToSaveField.Name = "DateToSaveField";
			this.DateToSaveField.Size = new System.Drawing.Size(200, 20);
			this.DateToSaveField.TabIndex = 14;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(861, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "Last Seed:";
			// 
			// LastSeedLabel
			// 
			this.LastSeedLabel.AutoSize = true;
			this.LastSeedLabel.Location = new System.Drawing.Point(926, 13);
			this.LastSeedLabel.Name = "LastSeedLabel";
			this.LastSeedLabel.Size = new System.Drawing.Size(43, 13);
			this.LastSeedLabel.TabIndex = 16;
			this.LastSeedLabel.Text = "<none>";
			// 
			// PicMakerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 562);
			this.Controls.Add(this.LastSeedLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.DateToSaveField);
			this.Controls.Add(this.NumberToSaveField);
			this.Controls.Add(this.YSizeField);
			this.Controls.Add(this.XSizeField);
			this.Controls.Add(this.SaveABunchButton);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.GenerateButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ResultsBox);
			this.MinimumSize = new System.Drawing.Size(1200, 600);
			this.Name = "PicMakerForm";
			this.Text = "PicMaker";
			this.Load += new System.EventHandler(this.PicMakerForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.ResultsBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ResultsBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button GenerateButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button SaveABunchButton;
		private System.Windows.Forms.TextBox XSizeField;
		private System.Windows.Forms.TextBox YSizeField;
		private System.Windows.Forms.TextBox NumberToSaveField;
		private System.Windows.Forms.Timer ThreadWatcher;
		private System.Windows.Forms.DateTimePicker DateToSaveField;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label LastSeedLabel;
    }
}

