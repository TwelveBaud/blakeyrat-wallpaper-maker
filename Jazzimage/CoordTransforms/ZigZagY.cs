using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	class ZigZagY : TransformParent
	{
		double _zigAmount;

		public ZigZagY()
		{
			int numberOfZigs = RandomNumberProvider.GetInt(100);
			_zigAmount = 1.0 / numberOfZigs;
		}

		public override PointColor Transform(PointColor input)
		{
			double inX = input.X;
			double inY = input.Y;

			double yOffset = inY % _zigAmount;

			if (yOffset > (_zigAmount / 2))
			{
				yOffset = _zigAmount - yOffset;
			}
			double outX = inX + yOffset;

			input.X = outX;

			return input;
		}
	}
}
