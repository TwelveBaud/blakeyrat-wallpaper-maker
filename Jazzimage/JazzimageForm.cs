﻿using System;
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

		public JazzimageForm()
		{
			InitializeComponent();
		}

		private void NewImageButton_Click(object sender, EventArgs e)
		{
			_jazzImage = new JazzImageDefinition(IMAGE_WIDTH, IMAGE_HEIGHT);

			RenderPicture.Image = _jazzImage.GetResultingImageThreaded();

			VoteUpButton.Enabled = true;
			VoteDownButton.Enabled = true;
		}

		private void NextFrameButton_Click(object sender, EventArgs e)
		{
			_jazzImage.NextFrame();

			RenderPicture.Image = _jazzImage.GetResultingImageThreaded();
		}

		private void MovieButton_Click(object sender, EventArgs e)
		{
			//int frameNum = 0;

			//while (true)
			//{
			//    frameNum++;
			//    _jazzImage.NextFrame();
			//    Image frame = _jazzImage.GetResultingImageThreaded();
			//    frame.Save( "frame_" + FormatInt(frameNum) + ".png", System.Drawing.Imaging.ImageFormat.Png);
			//}
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
			DateTime currentDate = new DateTime(2013, 01, 01);
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
	}
}
