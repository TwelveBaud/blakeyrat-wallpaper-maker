using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;
using System.Windows.Media.Imaging;

namespace PicMaker
{
    public partial class PicMakerForm : Form
    {
		private Bitmap m_image = null;
		private string m_basePath = null;
		private Thread m_worker = null;
		private Random m_rand = new Random();
		
		public PicMakerForm()
        {
            InitializeComponent();
        }

		private void PicMakerForm_Load(object sender, EventArgs e)
		{
		}

		private void ResultsBox_Click(object sender, EventArgs e)
		{

		}

		private void GenerateButton_Click(object sender, EventArgs e)
		{
			int xSize = Convert.ToInt32(XSizeField.Text);
			int ySize = Convert.ToInt32(YSizeField.Text);
			int seed = m_rand.Next();
			
			m_image = new Bitmap(xSize, ySize);
			m_image = PicMaker.CreatePic(xSize, ySize, seed);
			ResultsBox.Image = m_image;
			LastSeedLabel.Text = Convert.ToString(seed);
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "PNG Images (*.png)|*.png";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				m_image.Save(dialog.FileName);
				WriteSeedData(DateTime.Now, Convert.ToInt32(LastSeedLabel.Text));
			}
		}

		private void SaveABunchButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "PNG Images (*.png)|*.png";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				GenerateButton.Enabled = false;
				SaveButton.Enabled = false;
				SaveABunchButton.Enabled = false;
				XSizeField.Enabled = false;
				YSizeField.Enabled = false;
				NumberToSaveField.Enabled = false;
				DateToSaveField.Enabled = false;
				
				m_basePath = Path.GetDirectoryName(dialog.FileName);

				m_worker = new Thread(SaveABunchThread);
				m_worker.Start();
				ThreadWatcher.Enabled = true;
			}
		}

		void SaveABunchThread()
		{
			int xSize = Convert.ToInt32(XSizeField.Text);
			int ySize = Convert.ToInt32(YSizeField.Text);

			DateTime currentDate = DateToSaveField.Value;

			for (int i = 0; i < Convert.ToInt32(NumberToSaveField.Text); i++)
			{
				int seed = m_rand.Next();
				
				Bitmap thisImage = new Bitmap(xSize, ySize);
				thisImage = PicMaker.CreatePic(xSize, ySize, seed);
				LastSeedLabel.Text = Convert.ToString(seed);

				string filename = m_basePath + Path.DirectorySeparatorChar + currentDate.ToString("yyyyMMdd");
				thisImage.Save(filename + ".png");
				WriteSeedData(DateTime.Now, seed);

				Image thumbnail = thisImage.GetThumbnailImage(xSize / 4, ySize / 4, null, new IntPtr());
				thumbnail.Save(filename + "_thumb.png");

				// Next day
				currentDate = currentDate.AddDays(1);

				m_image = thisImage;
				ResultsBox.Image = m_image;
			}
		}

		void SaveABunchFinish()
		{
			ThreadWatcher.Enabled = false;
			
			GenerateButton.Enabled = true;
			SaveButton.Enabled = true;
			SaveABunchButton.Enabled = true;
			XSizeField.Enabled = true;
			YSizeField.Enabled = true;
			NumberToSaveField.Enabled = true;
			DateToSaveField.Enabled = true;
		}

		private void ThreadWatcher_Tick(object sender, EventArgs e)
		{
			if (m_worker.IsAlive != true)
			{
				SaveABunchFinish();
			}
		}

		public static byte[] StrToByteArray(string str)
		{
			System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
			return encoding.GetBytes(str);
		}

		private void WriteSeedData( DateTime generationDate, int seed )
		{
			
			TextWriter writer = new StreamWriter("data.txt", true);
			writer.WriteLine(Convert.ToString(generationDate) + "\t" + Convert.ToString(seed));
			writer.Close();
		}
    }
}
