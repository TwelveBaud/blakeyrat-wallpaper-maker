namespace Jazzimage
{
	partial class JazzimageForm
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
			this.RenderPicture = new System.Windows.Forms.PictureBox();
			this.NewImageButton = new System.Windows.Forms.Button();
			this.NextFrameButton = new System.Windows.Forms.Button();
			this.MovieButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.SaveBunchButton = new System.Windows.Forms.Button();
			this.InverseButton = new System.Windows.Forms.Button();
			this.VoteUpButton = new System.Windows.Forms.Button();
			this.VoteDownButton = new System.Windows.Forms.Button();
			this.VotesLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.RenderPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// RenderPicture
			// 
			this.RenderPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RenderPicture.BackColor = System.Drawing.Color.White;
			this.RenderPicture.Location = new System.Drawing.Point(13, 42);
			this.RenderPicture.Name = "RenderPicture";
			this.RenderPicture.Size = new System.Drawing.Size(759, 408);
			this.RenderPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.RenderPicture.TabIndex = 0;
			this.RenderPicture.TabStop = false;
			// 
			// NewImageButton
			// 
			this.NewImageButton.Location = new System.Drawing.Point(13, 12);
			this.NewImageButton.Name = "NewImageButton";
			this.NewImageButton.Size = new System.Drawing.Size(75, 23);
			this.NewImageButton.TabIndex = 1;
			this.NewImageButton.Text = "New Image";
			this.NewImageButton.UseVisualStyleBackColor = true;
			this.NewImageButton.Click += new System.EventHandler(this.NewImageButton_Click);
			// 
			// NextFrameButton
			// 
			this.NextFrameButton.Location = new System.Drawing.Point(94, 12);
			this.NextFrameButton.Name = "NextFrameButton";
			this.NextFrameButton.Size = new System.Drawing.Size(75, 23);
			this.NextFrameButton.TabIndex = 2;
			this.NextFrameButton.Text = "Next Frame";
			this.NextFrameButton.UseVisualStyleBackColor = true;
			this.NextFrameButton.Click += new System.EventHandler(this.NextFrameButton_Click);
			// 
			// MovieButton
			// 
			this.MovieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MovieButton.Location = new System.Drawing.Point(697, 12);
			this.MovieButton.Name = "MovieButton";
			this.MovieButton.Size = new System.Drawing.Size(75, 23);
			this.MovieButton.TabIndex = 3;
			this.MovieButton.Text = "Movie";
			this.MovieButton.UseVisualStyleBackColor = true;
			this.MovieButton.Click += new System.EventHandler(this.MovieButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveButton.Location = new System.Drawing.Point(535, 12);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 4;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// SaveBunchButton
			// 
			this.SaveBunchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveBunchButton.Location = new System.Drawing.Point(616, 12);
			this.SaveBunchButton.Name = "SaveBunchButton";
			this.SaveBunchButton.Size = new System.Drawing.Size(75, 23);
			this.SaveBunchButton.TabIndex = 5;
			this.SaveBunchButton.Text = "Save Bunch";
			this.SaveBunchButton.UseVisualStyleBackColor = true;
			this.SaveBunchButton.Click += new System.EventHandler(this.SaveBunchButton_Click);
			// 
			// InverseButton
			// 
			this.InverseButton.Location = new System.Drawing.Point(175, 12);
			this.InverseButton.Name = "InverseButton";
			this.InverseButton.Size = new System.Drawing.Size(75, 23);
			this.InverseButton.TabIndex = 6;
			this.InverseButton.Text = "Inverse";
			this.InverseButton.UseVisualStyleBackColor = true;
			this.InverseButton.Click += new System.EventHandler(this.InverseButton_Click);
			// 
			// VoteUpButton
			// 
			this.VoteUpButton.Enabled = false;
			this.VoteUpButton.Location = new System.Drawing.Point(315, 12);
			this.VoteUpButton.Name = "VoteUpButton";
			this.VoteUpButton.Size = new System.Drawing.Size(75, 23);
			this.VoteUpButton.TabIndex = 7;
			this.VoteUpButton.Text = "Vote +";
			this.VoteUpButton.UseVisualStyleBackColor = true;
			this.VoteUpButton.Click += new System.EventHandler(this.VoteUpButton_Click);
			// 
			// VoteDownButton
			// 
			this.VoteDownButton.Enabled = false;
			this.VoteDownButton.Location = new System.Drawing.Point(396, 12);
			this.VoteDownButton.Name = "VoteDownButton";
			this.VoteDownButton.Size = new System.Drawing.Size(75, 23);
			this.VoteDownButton.TabIndex = 8;
			this.VoteDownButton.Text = "Vote -";
			this.VoteDownButton.UseVisualStyleBackColor = true;
			this.VoteDownButton.Click += new System.EventHandler(this.VoteDownButton_Click);
			// 
			// VotesLabel
			// 
			this.VotesLabel.AutoSize = true;
			this.VotesLabel.Location = new System.Drawing.Point(296, 17);
			this.VotesLabel.Name = "VotesLabel";
			this.VotesLabel.Size = new System.Drawing.Size(13, 13);
			this.VotesLabel.TabIndex = 9;
			this.VotesLabel.Text = "?";
			// 
			// JazzimageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 462);
			this.Controls.Add(this.VotesLabel);
			this.Controls.Add(this.VoteDownButton);
			this.Controls.Add(this.VoteUpButton);
			this.Controls.Add(this.InverseButton);
			this.Controls.Add(this.SaveBunchButton);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.MovieButton);
			this.Controls.Add(this.NextFrameButton);
			this.Controls.Add(this.NewImageButton);
			this.Controls.Add(this.RenderPicture);
			this.MinimumSize = new System.Drawing.Size(800, 500);
			this.Name = "JazzimageForm";
			this.Text = "Jazzimage";
			((System.ComponentModel.ISupportInitialize)(this.RenderPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox RenderPicture;
		private System.Windows.Forms.Button NewImageButton;
		private System.Windows.Forms.Button NextFrameButton;
		private System.Windows.Forms.Button MovieButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button SaveBunchButton;
		private System.Windows.Forms.Button InverseButton;
		private System.Windows.Forms.Button VoteUpButton;
		private System.Windows.Forms.Button VoteDownButton;
		private System.Windows.Forms.Label VotesLabel;
	}
}

