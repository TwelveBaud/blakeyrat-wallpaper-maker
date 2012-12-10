using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Threading;

namespace Jazzimage
{
	class JazzImageDefinition
	{
		const int NUMBER_OF_THREADS = 8;

		int _numTransforms;
		List<TransformParent> _transforms;
		int _width;
		int _height;

		Image _threadResults;
		Graphics _threadGraf;

		public JazzImageDefinition(int width, int height)
		{
			_transforms = new List<TransformParent>();
			_numTransforms = TransformVoting.GetNumTransforms();

			for (int i = 0; i < (_numTransforms - 1); i++)
			{
				//_transforms.Add(SelectRandomTransform());

				if (i % 3 == 0)
				{
					_transforms.Add(TransformVoting.GetColorTransform());
				}
				else
				{
					_transforms.Add(TransformVoting.GetCoordTransform());
				}
			}

			_transforms.Add(TransformVoting.GetColorTransform());

			// For QAing specific transforms
			//_transforms.Add(new Swirl());
			//_transforms.Add(new HorizontalStripe());
			//_transforms.Add(new VerticalStripe());

			_width = width;
			_height = height;
		}

		public void NextFrame()
		{
			for (int i = 0; i < _transforms.Count; i++)
			{
				_transforms[i].NextFrame(0.001);
			}
		}

		public Image GetResultingImage()
		{
			return GetImageRect(0, 0, _width, _height);
		}

		public Image GetResultingImageThreaded()
		{
			_threadResults = new Bitmap(_width, _height);
			_threadGraf = Graphics.FromImage(_threadResults);

			List<Thread> threads = new List<Thread>();

			for (int i = 0; i < NUMBER_OF_THREADS; i++)
			{
				Thread thread = new Thread(new ParameterizedThreadStart(ThreadManager));
				thread.Start(i);

				threads.Add(thread);
			}

			bool done = false;

			while (!done)
			{
				done = true;

				foreach (Thread thread in threads)
				{
					if (thread.IsAlive)
					{
						done = false;
						break;
					}
				}

				Thread.Sleep(10);
			}

			ThreadManager(0);

			// All threads done
			return _threadResults;
		}

		public void VoteUp()
		{
			double voteAmount = 1.0 / _numTransforms;

			TransformVoting.RecordVotes(_transforms, _numTransforms, voteAmount);
		}

		public void VoteDown()
		{
			double voteAmount = 1.0 / _numTransforms;
			voteAmount = -voteAmount;

			TransformVoting.RecordVotes(_transforms, _numTransforms, voteAmount);
		}

		protected Image GetImageRect(int left, int top, int width, int height)
		{
			Bitmap result = new Bitmap(width, height);

			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					//result.SetPixel(x, y, GetColorFromPointAntiAlias(x + left, y + top));
					result.SetPixel(x, y, GetColorFromPoint(x + left, y + top));
				}
			}

			return result;
		}

		protected void ThreadManager(object input)
		{
			int which = (int)input;

			for (int y = which; y < _height; y += NUMBER_OF_THREADS)
			{

				Image result = GetImageRect(0, y, _width, 1);

				lock (_threadGraf)
				{
					_threadGraf.DrawImage(result, 0, y);
				}
			}
		}

		public Color GetColorFromPoint(int x, int y)
		{
			PointColor pc = new PointColor((Convert.ToDouble(x) / _width), (Convert.ToDouble(y) / _height), Color.Transparent);

			return GetColorFromPointColor(pc);
		}

		const int NUMBER_OF_AA_POINTS = 5;

		public Color GetColorFromPointAntiAlias(int x, int y)
		{
			// Let's grab 3 colors, 120 degrees away from the center point, and average the values.
			double xDouble = Convert.ToDouble(x);
			double yDouble = Convert.ToDouble(y);

			List<Color> colors = new List<Color>();

			for (int i = 0; i < NUMBER_OF_AA_POINTS; i++)
			{
				PointColor pc = new PointColor();

				pc.X = xDouble + (RandomNumberProvider.GetDouble() - 0.5);
				pc.Y = yDouble + (RandomNumberProvider.GetDouble() - 0.5);

				Color c = GetColorFromPointColor(pc);

				colors.Add(c);
			}

			int aTotal = 0;
			int rTotal = 0;
			int gTotal = 0;
			int bTotal = 0;

			for (int j = 0; j < NUMBER_OF_AA_POINTS; j++)
			{
				aTotal += colors[j].A;
				rTotal += colors[j].R;
				gTotal += colors[j].G;
				bTotal += colors[j].B;
			}

			Color result = Color.FromArgb(aTotal / NUMBER_OF_AA_POINTS, rTotal / NUMBER_OF_AA_POINTS, gTotal / NUMBER_OF_AA_POINTS, bTotal / NUMBER_OF_AA_POINTS);

			return result;
		}

		public Color GetColorFromPointColor(PointColor pc)
		{
			pc.Color = Color.Transparent;

			for (int i = 0; i < _transforms.Count; i++)
			{
				pc = _transforms[i].Transform(pc);
			}

			pc.Color = Color.FromArgb(255, pc.Color.R, pc.Color.G, pc.Color.B);

			return pc.Color;
		}

		public Color GetColorFromPointInverse(int x, int y)
		{
			PointColor pc = new PointColor((Convert.ToDouble(x) / _width), (Convert.ToDouble(y) / _height), Color.Transparent);

			for (int i = _transforms.Count; i > 0; i--)
			{
				pc = _transforms[i - 1].Transform(pc);
			}

			pc.Color = Color.FromArgb(255, pc.Color.R, pc.Color.G, pc.Color.B);

			return pc.Color;
		}

		public int Width
		{
			get { return _width; }
		}

		public int Height
		{
			get { return _height; }
		}
	}
}
