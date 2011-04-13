using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicMaker
{
	class PicPoint
	{
		double m_x;
		double m_y;

		public PicPoint()
		{
			m_x = 0;
			m_y = 0;
		}

		public PicPoint(double x, double y)
		{
			m_x = x;
			m_y = y;
		}

		public double DistanceTo(double x, double y)
		{
			return (Math.Sqrt(Math.Pow((x - m_x), 2) + Math.Pow((y - m_y), 2)));
		}

		public double XDistanceTo(double x)
		{
			return (Math.Sqrt(Math.Pow((x - m_x), 2)));
		}

		public double YDistanceTo(double y)
		{
			return (Math.Sqrt(Math.Pow((y - m_y), 2)));
		}

		public PicPoint RotateAroundOrigin(int origX, int origY, double rot)
		{
			PicPoint result = new PicPoint(m_x, m_y);

			// Create a rotated point
			double offsetX = m_x - origX;
			double offsetY = m_y - origY;

			offsetX = offsetX * Math.Cos(rot) - offsetY * Math.Sin(rot);
			offsetY = offsetY * Math.Cos(rot) + offsetX * Math.Sin(rot);

			offsetX = offsetX + origX;
			offsetY = offsetY + origY;

			int rotX = Convert.ToInt32(offsetX);
			int rotY = Convert.ToInt32(offsetY);

			return (new PicPoint(rotX, rotY));
		}

		public bool InRectangle(int x0, int y0, int x1, int y1)
		{
			int x = Convert.ToInt32(m_x);
			int y = Convert.ToInt32(m_y);

			if (x > x0 && x < x1 && y > y0 && y < y1)
			{
				return (true);
			}

			return (false);
		}

		// Getters/Setters
		public double X
		{
			set { m_x = value; }
			get { return m_x; }
		}

		public double Y
		{
			set { m_y = value; }
			get { return m_y; }
		}
	}
}
