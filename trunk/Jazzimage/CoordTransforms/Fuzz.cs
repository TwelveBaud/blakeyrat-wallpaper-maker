using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	public class Fuzz : TransformParent
	{
		double _maxAmount;

		public Fuzz()
		{
			_maxAmount = RandomNumberProvider.GetDouble() * 0.05;
		}

		public override PointColor Transform(PointColor input)
		{
			input.X = input.X + (RandomNumberProvider.GetDouble() * _maxAmount);
			input.Y = input.Y + (RandomNumberProvider.GetDouble() * _maxAmount);

			return input;
		}
	}
}
