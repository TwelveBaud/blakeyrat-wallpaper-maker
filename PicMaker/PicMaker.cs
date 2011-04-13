using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;

namespace PicMaker
{
	static class PicMaker
	{
		public struct Nexus
		{
			public PicPoint point;
			public bool roundPoint;
			public int boost;
		}

		static public Bitmap CreatePic(int xSize, int ySize, int seed)
		{
			return (CreatePicV1(xSize, ySize, seed));

			// Below blends two images
			//Bitmap v1 = CreatePicV1(xSize, ySize, seed);
			//seed++;
			//Bitmap v2 = CreatePicV2(xSize, ySize, seed);

			//Bitmap final = new Bitmap(xSize, ySize);
			//Graphics finalG = Graphics.FromImage(final);

			//float[][] ptsArray ={ 
			//        new float[] {1, 0, 0, 0, 0},
			//        new float[] {0, 1, 0, 0, 0},
			//        new float[] {0, 0, 1, 0, 0},
			//        new float[] {0, 0, 0, 0.5f, 0}, 
			//        new float[] {0, 0, 0, 0, 1}
			//    };
			//ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
			//ImageAttributes imgAttr = new ImageAttributes();
			//imgAttr.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

			//finalG.DrawImage(v1, new Rectangle(0, 0, v1.Width, v1.Height), 0, 0, v1.Width, v1.Height, GraphicsUnit.Pixel, imgAttr);
			//finalG.DrawImage(v2, new Rectangle(0, 0, v2.Width, v2.Height), 0, 0, v2.Width, v2.Height, GraphicsUnit.Pixel, imgAttr);

			//finalG.DrawImage(v1, new Rectangle(0, 0, 200, 200));
			//finalG.DrawImage(v2, new Rectangle(200, 0, 200, 200));

			//finalG.Save();

			//return (final);
		}

		// V1 generated images for www.hiareyou.com year 2011
		static public Bitmap CreatePicV1(int xSize, int ySize, int seed)
		{
			Random rand = new Random(seed);

			List<Nexus> nexii = new List<Nexus>();
			List<double> rotations = new List<double>();
			double[,] values = new double[xSize, ySize];

			// Moving this up here so it picks the same gradient for the same seed
			PicGradient grad = new PicGradient(rand.Next());

			// Random params
			double maxDist = Convert.ToDouble(Math.Max(xSize, ySize) / (rand.NextDouble() * 3));
			double maxFuzz = (rand.NextDouble() * 0.1);
			int mod = rand.Next(16) + 2;
			int numPoints = rand.Next(256) + 8;
			double rotation = rand.NextDouble() * (2 * Math.PI);
			int boostPoints = rand.Next(numPoints / 2);
			int superBoostPoints = rand.Next(boostPoints / 3);

			double minPointValue = Double.MaxValue;
			double maxPointValue = Double.MinValue;

			// Generate nexii
			for (int i = 0; i < numPoints; i++)
			{
				Nexus nexus = new Nexus();

				double randX = (rand.NextDouble() * (Convert.ToDouble(xSize) * 3)) - Convert.ToDouble(xSize);
				double randY = (rand.NextDouble() * (Convert.ToDouble(ySize) * 3)) - Convert.ToDouble(ySize);
				nexus.point = new PicPoint(randX, randY);

				nexus.roundPoint = false;
				nexus.boost = 1;

				if (i < boostPoints)
				{
					nexus.boost = 2;
					if (i < superBoostPoints)
					{
						nexus.boost = 3;
					}
				}

				nexii.Add(nexus);
			}

			// Find value for each point
			for (int x = 0; x < xSize; x++)
			{
				for (int y = 0; y < ySize; y++)
				{
					double pointValue = 0;

					// Store original point
					PicPoint origPt = new PicPoint(x - (xSize / 2), y - (ySize / 2));

					PicPoint finalPt = origPt;
					finalPt.RotateAroundOrigin(0, 0, rotation);

					for (int z = 0; z < nexii.Count; z++)
					{
						double dist = 0.0;

						// Mod determines whether to judge distance on X, Y, or both (majority will be both)
						switch (z % mod)
						{
							case 0:
								dist = nexii[z].point.XDistanceTo(finalPt.X);
								break;
							case 1:
								dist = nexii[z].point.YDistanceTo(finalPt.Y);
								break;
							default:
								dist = nexii[z].point.DistanceTo(finalPt.X, finalPt.Y);
								break;
						}

						if (dist < maxDist)
						{
							pointValue += dist * nexii[z].boost;
						}
					}

					// Apply "fuzz factor"
					double fuzz = rand.NextDouble() * maxFuzz;
					pointValue += pointValue * fuzz;

					// Verify min/max point value are still correct
					if (pointValue < minPointValue)
					{
						minPointValue = pointValue;
					}
					if (pointValue > maxPointValue)
					{
						maxPointValue = pointValue;
					}

					values[x, y] = pointValue;
				}
			}

			Bitmap pic = new Bitmap(xSize, ySize);

			for (int x = 0; x < pic.Width; x++)
			{
				for (int y = 0; y < pic.Height; y++)
				{
					double uncorrectedValue = values[x, y];
					double value = (uncorrectedValue - minPointValue) / (maxPointValue - minPointValue);

					Color c = grad.GetColorAtValue(value);

					pic.SetPixel(x, y, c);
				}
			}

			return (pic);
		}

		// V1 generated images for www.hiareyou.com year 2012
		static public Bitmap CreatePicV2(int xSize, int ySize, int seed)
		{
			Random rand = new Random(seed);

			List<Nexus> nexii = new List<Nexus>();
			List<double> rotations = new List<double>();
			double[,] values = new double[xSize, ySize];

			// Moving this up here so it picks the same gradient each time
			PicGradient grad = new PicGradient(rand.Next());

			// Random params
			double maxDist = Convert.ToDouble(Math.Max(xSize, ySize) / (rand.NextDouble() * 3));
			double maxFuzz = (rand.NextDouble() * 0.1);
			int mod = rand.Next(16) + 2;
			int numPoints = rand.Next(256) + 8;
			double rotation = rand.NextDouble() * (2 * Math.PI);

			double minPointValue = Double.MaxValue;
			double maxPointValue = Double.MinValue;

			// Generate nexii
			for (int i = 0; i < numPoints; i++)
			{
				Nexus nexus = new Nexus();

				double randX = (rand.NextDouble() * (Convert.ToDouble(xSize) * 3)) - Convert.ToDouble(xSize);
				double randY = (rand.NextDouble() * (Convert.ToDouble(ySize) * 3)) - Convert.ToDouble(ySize);
				nexus.point = new PicPoint(randX, randY);

				nexus.roundPoint = false;
				nexus.boost = 1;

				if (rand.NextDouble() < .5)
				{
					nexus.roundPoint = true;
				}

				while (rand.NextDouble() < 0.33333333)
				{
					nexus.boost++;
				}

				nexii.Add(nexus);
			}

			// Find value for each point
			for (int x = 0; x < xSize; x++)
			{
				for (int y = 0; y < ySize; y++)
				{
					double pointValue = 0;

					// Store original point
					PicPoint origPt = new PicPoint(x - (xSize / 2), y - (ySize / 2));

					PicPoint rotPt = origPt;
					rotPt.RotateAroundOrigin(0, 0, rotation);

					for (int z = 0; z < nexii.Count; z++)
					{
						double dist = 0.0;
						PicPoint finalPt = new PicPoint();

						if (nexii[z].roundPoint == true)
						{
							finalPt = origPt;
						}
						else
						{
							finalPt = rotPt;
						}

						// Mod determines whether to judge distance on X, Y, or both (majority will be both)
						switch (z % mod)
						{
							case 0:
								dist = nexii[z].point.XDistanceTo(finalPt.X);
								break;
							case 1:
								dist = nexii[z].point.YDistanceTo(finalPt.Y);
								break;
							default:
								dist = nexii[z].point.DistanceTo(finalPt.X, finalPt.Y);
								break;
						}

						if (dist < maxDist)
						{
							pointValue += Math.Pow(dist, Convert.ToDouble(nexii[z].boost));
						}
					}

					// Apply "fuzz factor"
					double fuzz = rand.NextDouble() * maxFuzz;
					pointValue += pointValue * fuzz;

					// Verify min/max point value are still correct
					if (pointValue < minPointValue)
					{
						minPointValue = pointValue;
					}
					if (pointValue > maxPointValue)
					{
						maxPointValue = pointValue;
					}

					values[x, y] = pointValue;
				}
			}

			Bitmap pic = new Bitmap(xSize, ySize);

			for (int x = 0; x < pic.Width; x++)
			{
				for (int y = 0; y < pic.Height; y++)
				{
					double uncorrectedValue = values[x, y];
					double value = (uncorrectedValue - minPointValue) / (maxPointValue - minPointValue);

					Color c = grad.GetColorAtValue(value);

					pic.SetPixel(x, y, c);
				}
			}

			return (pic);
		}
	}
}
