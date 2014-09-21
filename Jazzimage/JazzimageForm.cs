using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using System.IO;

namespace Jazzimage
{
	public partial class JazzimageForm : Form
	{
		static int IMAGE_WIDTH = 1920 * 2;
		//static int IMAGE_WIDTH = 320;
		static int IMAGE_HEIGHT = 1080 * 2;
		//static int IMAGE_HEIGHT = 240;

		private JazzImageDefinition _jazzImage;
		private Thread _callbackThread;

		public JazzimageForm()
		{
			InitializeComponent();
		}

		private void NewImageButton_Click(object sender, EventArgs e)
		{
			_jazzImage = new JazzImageDefinition(IMAGE_WIDTH, IMAGE_HEIGHT);

			RenderPicture.Image = _jazzImage.GetResultingImageThreaded();

			EnableAllButtons();
		}

		private void NextFrameButton_Click(object sender, EventArgs e)
		{
			int numberFrames = Convert.ToInt32(FrameNumsField.Text);

			_jazzImage.NextFrame(numberFrames);

			RenderPicture.Image = _jazzImage.GetResultingImageThreaded();
		}

		private void MovieButton_Click(object sender, EventArgs e)
		{
			int numberFrames = Convert.ToInt32(FrameNumsField.Text);

			_jazzImage.Height = 1080;
			_jazzImage.Width = 1920;
			
			for( int i = 0; i < numberFrames; i++)
			{
				_jazzImage.NextFrame(300);
				Image frame = _jazzImage.GetResultingImageThreaded();
				RenderPicture.Image = frame;
				frame.Save("frame_" + FormatInt(i) + ".png", System.Drawing.Imaging.ImageFormat.Png);
			}
		}

		private string FormatInt(int a)
		{
			string result = "";

			if (a < 100)
			{
				result = "0";
			}
			if (a < 10)
			{
				result += "0";
			}

			result += a;

			return result;
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			RenderPicture.Image.Save("saved.png", System.Drawing.Imaging.ImageFormat.Png);
		}

		private void SaveBunchButton_Click(object sender, EventArgs e)
		{
			while (true)
			{
				_jazzImage = new JazzImageDefinition(IMAGE_WIDTH, IMAGE_HEIGHT);
				Image frame = _jazzImage.GetResultingImageThreaded();
				//Image frame = _jazzImage.GetResultingImage();

				string filename = GetNextFilename();

				while (filename == null)
				{
					Thread.Sleep(10000);
					filename = GetNextFilename();
				}

				frame.Save(filename, System.Drawing.Imaging.ImageFormat.Png);

				Image thumbnail = frame.GetThumbnailImage(frame.Width / 4, frame.Height / 4, null, new IntPtr());
				thumbnail.Save(filename.Split('.')[0] + "_thumb.png");

				Thread.Sleep(1000);
			}
		}

		private string GetNextFilename()
		{
			DateTime currentDate = new DateTime(2015, 01, 01);
			int dayCount = 0;

			while (true)
			{
				string filename = currentDate.ToString("yyyyMMdd");

				if (!File.Exists(filename + ".png"))
				{
					return filename + ".png";
				}

				dayCount++;

				if (dayCount > 366)
				{
					return null;
				}

				currentDate = currentDate.AddDays(1);
			}
		}

		private void InverseButton_Click(object sender, EventArgs e)
		{
			//RenderPicture.Image = _jazzImage.GetResultingImageThreaded();
		}

		private void VoteUpButton_Click(object sender, EventArgs e)
		{
			_jazzImage.VoteUp();

			VoteUpButton.Enabled = false;
			VoteDownButton.Enabled = false;

			VotesLabel.Text = Convert.ToString(TransformVoting.GetNumVotes());
		}

		private void VoteDownButton_Click(object sender, EventArgs e)
		{
			_jazzImage.VoteDown();

			VoteUpButton.Enabled = false;
			VoteDownButton.Enabled = false;

			VotesLabel.Text = Convert.ToString(TransformVoting.GetNumVotes());
		}

		private void DisableAllButtons()
		{
			NewImageButton.Enabled = false;
			NextFrameButton.Enabled = false;
			InverseButton.Enabled = false;
			VoteUpButton.Enabled = false;
			VoteDownButton.Enabled = false;
			SaveButton.Enabled = false;
			SaveBunchButton.Enabled = false;
			MovieButton.Enabled = false;
		}

		private void EnableAllButtons()
		{
			NewImageButton.Enabled = true;
			NextFrameButton.Enabled = true;
			InverseButton.Enabled = true;
			if (_jazzImage != null)
			{
				VoteUpButton.Enabled = true;
				VoteDownButton.Enabled = true;
			}
			SaveButton.Enabled = true;
			SaveBunchButton.Enabled = true;
			MovieButton.Enabled = true;
		}
	}
}
