using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	class ZigZagX : TransformParent
	{
		double _zigAmount;

		public ZigZagX()
		{
			int numberOfZigs = RandomNumberProvider.GetInt(100);
			_zigAmount = 1.0 / numberOfZigs;
		}

		public override PointColor Transform(PointColor input)
		{
			double inX = input.X;
			double inY = input.Y;

			double xOffset = inX % _zigAmount;
			if (xOffset > (_zigAmount / 2))
			{
				xOffset = _zigAmount - xOffset;
			}
			double outY = inY + xOffset;

			input.Y = outY;

			return input;
		}
	}
}
