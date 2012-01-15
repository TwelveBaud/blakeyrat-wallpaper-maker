using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	class Fisheye : TransformParent
	{
		double _amount;

		public Fisheye()
		{
			_amount = RandomNumberProvider.GetRandDouble() * (2 * Math.PI);
		}

		public override PointColor Transform(PointColor input)
		{
			double inX = input.X - 0.5;
			double inY = input.Y - 0.5;

			double dist = Math.Sqrt(Math.Pow(inX, 2.0) + Math.Pow(inY, 2.0));
			double outX = inX + (inX * Math.Sin(dist * _amount));
			double outY = inY + (inY * Math.Sin(dist * _amount));

			input.X = outX + 0.5;
			input.Y = outY + 0.5;

			return input;
		}
	}
}
