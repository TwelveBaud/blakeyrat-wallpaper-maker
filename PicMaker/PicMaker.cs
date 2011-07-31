using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace PicMaker
{
	class PicMaker
	{
		// Consts
		const int MAX_THREAD_NUMBER = 8;

		// Structs
		public struct Nexus
		{
			public PicPoint point;
			public bool roundPoint;
			public int boost;
		}

		// Members
		protected Random _rand;
		protected Object _lockObject = new Object();

		protected PicGradient _grad;
		protected int _xSize;
		protected int _ySize;
		protected double _maxDist;
		protected double _maxFuzz;
		protected int _mod;
		protected int _numPoints;
		protected double _rotation;
		protected int _boostPoints;
		protected int _superBoostPoints;
		protected List<Nexus> _nexii;
		protected double _minPointValue;
		protected double _maxPointValue;

		protected double[,] _values;

		public PicMaker(int xSize, int ySize, int? seed)
		{
			if (seed == null)
			{
				_rand = new Random();
			}
			else
			{
				_rand = new Random(Convert.ToInt32(seed));
			}

			_grad = new PicGradient(_rand.Next());

			_xSize = xSize;
			_ySize = ySize;

			// Image params
			_xSize = xSize;
			_ySize = ySize;
			_maxDist = Convert.ToDouble(Math.Max(xSize, ySize) / (_rand.NextDouble() * 3));
			_maxFuzz = (_rand.NextDouble() * 0.1);
			_mod = _rand.Next(16) + 2;
			_numPoints = _rand.Next(256) + 8;
			_rotation = _rand.NextDouble() * (2 * Math.PI);
			_boostPoints = _rand.Next(_numPoints / 2);
			_superBoostPoints = _rand.Next(_boostPoints / 3);
			_nexii = new List<Nexus>();

			_values = new double[_xSize, _ySize];
			_minPointValue = Double.MaxValue;
			_maxPointValue = Double.MinValue;

			// Generate nexii
			for (int i = 0; i < _numPoints; i++)
			{
				Nexus nexus = new Nexus();

				double randX = (_rand.NextDouble() * (Convert.ToDouble(xSize) * 3)) - Convert.ToDouble(xSize);
				double randY = (_rand.NextDouble() * (Convert.ToDouble(ySize) * 3)) - Convert.ToDouble(ySize);
				nexus.point = new PicPoint(randX, randY);

				nexus.roundPoint = false;
				nexus.boost = 1;

				if (i < _boostPoints)
				{
					nexus.boost = 2;
					if (i < _superBoostPoints)
					{
						nexus.boost = 3;
					}
				}

				_nexii.Add(nexus);
			}
		}

		public Bitmap CreatePic()
		{
			ResetValues();

			CreatePixelValuesForRectangle(0, 0, _xSize - 1, _ySize - 1);

			return (CreateBitmapFromPixelValues());
		}

		public Bitmap CreatePicThread()
		{
			ResetValues();

			List<Thread> threadList = new List<Thread>();

			for (int i = 0; i < MAX_THREAD_NUMBER; i++)
			{
				int x1 = 0;
				int x2 = _xSize - 1;
				int y1 = (_ySize / MAX_THREAD_NUMBER) * i;
				int y2 = ((_ySize / MAX_THREAD_NUMBER) * (i + 1)) - 1;

				List<int> rectValues = new List<int>();
				rectValues.Add(x1);
				rectValues.Add(y1);
				rectValues.Add(x2);
				rectValues.Add(y2);

				Thread thread = new Thread(CreatePicThreadHandler);
				thread.Start(rectValues);
				threadList.Add(thread);
			}

			bool finished = false;

			while (!finished)
			{
				finished = true;

				for (int i = 0; i < threadList.Count; i++)
				{
					if (threadList[i].IsAlive)
					{
						finished = false;
					}
				}

				Thread.Sleep(10);
			}

			return (CreateBitmapFromPixelValues());
		}

		protected void CreatePicThreadHandler(Object paramObj)
		{
			List<int> rectValues = (List<int>)paramObj;

			CreatePixelValuesForRectangle(rectValues[0], rectValues[1], rectValues[2], rectValues[3]);
		}

		protected void ResetValues()
		{
			_values = new double[_xSize, _ySize];
			_minPointValue = Double.MaxValue;
			_maxPointValue = Double.MinValue;
		}

		protected void CreatePixelValuesForRectangle(int x1, int y1, int x2, int y2)
		{
			double maxPointValue = double.MinValue;
			double minPointValue = double.MaxValue;

			// Find value for each point
			for (int x = x1; x <= x2; x++)
			{
				for (int y = y1; y <= y2; y++)
				{
					double pointValue = GetPixelValue(x, y);

					// Verify min/max point value are still correct
					if (pointValue < minPointValue)
					{
						minPointValue = pointValue;
					}
					if (pointValue > maxPointValue)
					{
						maxPointValue = pointValue;
					}

					lock (_lockObject)
					{
						_values[x, y] = pointValue;
					}
				}
			}

			lock (_lockObject)
			{
				if (minPointValue < _minPointValue)
				{
					_minPointValue = minPointValue;
				}

				if (maxPointValue > _maxPointValue)
				{
					_maxPointValue = maxPointValue;
				}
			}
		}

		protected Bitmap CreateBitmapFromPixelValues()
		{
			Bitmap pic = new Bitmap(_xSize, _ySize);

			// Correct maxPointValue for fuzz factor
			_maxPointValue += _maxPointValue * _maxFuzz;

			for (int x = 0; x < pic.Width; x++)
			{
				for (int y = 0; y < pic.Height; y++)
				{
					double uncorrectedValue = _values[x, y];

					// Apply "fuzz factor"
					double fuzz = _rand.NextDouble() * _maxFuzz;
					uncorrectedValue += uncorrectedValue * fuzz;

					double value = (uncorrectedValue - _minPointValue) / (_maxPointValue - _minPointValue);

					Color c = _grad.GetColorAtValue(value);

					pic.SetPixel(x, y, c);
				}
			}

			return (pic);
		}

		protected double GetPixelValue(int x, int y)
		{
			double pointValue = 0;

			// Store original point
			PicPoint origPt = new PicPoint(x - (_xSize / 2), y - (_ySize / 2));

			PicPoint finalPt = origPt;
			finalPt.RotateAroundOrigin(0, 0, _rotation);

			for (int z = 0; z < _nexii.Count; z++)
			{
				double dist = 0.0;

				// Mod determines whether to judge distance on X, Y, or both (majority will be both)
				switch (z % _mod)
				{
					case 0:
						dist = _nexii[z].point.XDistanceTo(finalPt.X);
						break;
					case 1:
						dist = _nexii[z].point.YDistanceTo(finalPt.Y);
						break;
					default:
						dist = _nexii[z].point.DistanceTo(finalPt.X, finalPt.Y);
						break;
				}

				if (dist < _maxDist)
				{
					pointValue += dist * _nexii[z].boost;
				}
			}

			return (pointValue);
		}
	}
}
