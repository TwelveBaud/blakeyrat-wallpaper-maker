using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	public class Fuzz : TransformParent
	{
		protected double _maxAmount;

		public Fuzz()
		{
			_maxAmount = NumberUtils.GetRandDouble() * 0.05;
		}

		public override PointColor Transform(PointColor input)
		{
			input.X = input.X + (NumberUtils.GetRandDouble() * _maxAmount);
			input.Y = input.Y + (NumberUtils.GetRandDouble() * _maxAmount);

			return input;
		}
	}
}
