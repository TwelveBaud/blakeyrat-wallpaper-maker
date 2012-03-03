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
		const int NUMBER_OF_TRANSFORM_LAYERS = 12;
		const int NUMBER_OF_THREADS = 3;

		List<TransformParent> _transforms;
		int _width;
		int _height;

		Image _threadResults;
		Graphics _threadGraf;

		public JazzImageDefinition(int width, int height)
		{
			_transforms = new List<TransformParent>();

			for (int i = 0; i < (NUMBER_OF_TRANSFORM_LAYERS - 1); i++)
			{
				//_transforms.Add(SelectRandomTransform());

				if (i % 2 == 0)
				{
					_transforms.Add(SelectRandomTransform());
				}
				else
				{
					_transforms.Add(new MoveOrigin());
				}
			}

			_transforms.Add(SelectRandomColorTransform());

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

		public TransformParent SelectRandomTransform()
		{
			double selector = RandomNumberProvider.GetRandDouble() * (NUMBER_OF_COORD_TRANSFORMS + NUMBER_OF_COLOR_TRANSFORMS);

			if (selector < NUMBER_OF_COORD_TRANSFORMS)
			{
				return SelectRandomCoordTransform();
			}
			else
			{
				return SelectRandomColorTransform();
			}
		}

		const int NUMBER_OF_COORD_TRANSFORMS = 11;

		public TransformParent SelectRandomCoordTransform()
		{
			int transformSelector = RandomNumberProvider.GetRandInt(NUMBER_OF_COORD_TRANSFORMS);
			TransformParent transform = new TransformParent();

			switch (transformSelector)
			{
				case 0:
					transform = new BulgeX();
					break;
				case 1:
					transform = new BulgeY();
					break;
				case 2:
					transform = new Fisheye();
					break;
				case 3:
					transform = new Fuzz();
					break;
				case 4:
					transform = new Rotate();
					break;
				case 5:
					transform = new SineX();
					break;
				case 6:
					transform = new SineY();
					break;
				case 7:
					transform = new Swirl();
					break;
				case 8:
					transform = new TiltX();
					break;
				case 9:
					transform = new TiltY();
					break;
				case 10:
					transform = new ZoomOut();
					break;
				default:
					transform = new TransformParent();
					break;
			}

			return transform;
		}

		const int NUMBER_OF_COLOR_TRANSFORMS = 9;

		public TransformParent SelectRandomColorTransform()
		{
			int transformSelector = RandomNumberProvider.GetRandInt(NUMBER_OF_COLOR_TRANSFORMS);
			TransformParent transform = new TransformParent();

			switch (transformSelector)
			{
				case 0:
					transform = new AlterBlue();
					break;
				case 1:
					transform = new AlterGreen();
					break;
				case 2:
					transform = new AlterRed();
					break;
				case 3:
					transform = new Circle();
					break;
				case 4:
					transform = new FuzzAlpha();
					break;
				case 5:
					transform = new GreyscaleX();
					break;
				case 6:
					transform = new GreyscaleY();
					break;
				case 7:
					transform = new HorizontalStripe();
					break;
				case 8:
					transform = new VerticalStripe();
					break;
				default:
					transform = new TransformParent();
					break;
			}

			return transform;
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

				pc.X = xDouble + (RandomNumberProvider.GetRandDouble() - 0.5);
				pc.Y = yDouble + (RandomNumberProvider.GetRandDouble() - 0.5);

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
