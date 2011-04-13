using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace PicMaker
{
	class PicGradient
	{
		private SortedDictionary<double, Color> m_segments = new SortedDictionary<double, Color>();

		/// <summary>
		/// Generate a random gradient
		/// </summary>
		public PicGradient(int seed)
		{
			Random rand = new Random(seed);
			
			// Add beginning and end points
			m_segments.Add(0.0, GetRandomColor(rand));
			m_segments.Add(1.0, GetRandomColor(rand));

			// Determine number of intermediate points
			int loops = 1;
			double loopVal = rand.NextDouble();

			while (loopVal < (0.75 / loops))
			{
				m_segments.Add(rand.NextDouble(), GetRandomColor(rand));

				loops++;
			}
		}

		public Color GetColorAtValue(double value)
		{
			for (int i = 1; i < m_segments.Count; i++)
			{
				if (m_segments.ElementAt(i).Key > value)
				{
					double firstNum = m_segments.ElementAt(i - 1).Key;
					Color firstColor = m_segments.ElementAt(i - 1).Value;
					double secondNum = m_segments.ElementAt(i).Key;
					Color secondColor = m_segments.ElementAt(i).Value;

					double split = (value - firstNum) / (secondNum - firstNum);

					double r = (Convert.ToDouble(firstColor.R) * (1 - split)) + (Convert.ToDouble(secondColor.R) * split);
					double g = (Convert.ToDouble(firstColor.G) * (1 - split)) + (Convert.ToDouble(secondColor.G) * split);
					double b = (Convert.ToDouble(firstColor.B) * (1 - split)) + (Convert.ToDouble(secondColor.B) * split);

					return (Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b)));
				}
			}

			return (m_segments[1.0]);
		}

		/// <summary>
		/// Generate a random RGB color
		/// </summary>
		/// <returns></returns>
		private Color GetRandomColor(Random rand)
		{
			if (rand.NextDouble() < 0.33333333)
			{
				if (rand.NextDouble() < 0.33333333)
				{
					if (rand.NextDouble() < 0.5)
					{
						return (Color.White);
					}
					else
					{
						return (Color.Black);
					}
				}
				int value = rand.Next(256);
				return( Color.FromArgb(value, value, value ));
			}

			return (Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)));
		}
	}
}
