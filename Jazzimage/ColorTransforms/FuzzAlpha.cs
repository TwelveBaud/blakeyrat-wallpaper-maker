using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class FuzzAlpha : TransformParent
	{
		protected double _minValue;
		protected double _maxValue;

		public FuzzAlpha()
		{
			var value1 = RandomNumberProvider.GetDouble();
			var value2 = RandomNumberProvider.GetDouble();

			_minValue = Math.Min(value1, value2);
			_maxValue = Math.Max(value1, value2);
		}

		public override PointColor Transform(PointColor input)
		{
			double newAlpha = (RandomNumberProvider.GetDouble() * (_maxValue - _minValue)) + _minValue;

			input.Color = new DoubleColor(input.Color.R, input.Color.G, input.Color.B, newAlpha);

			return input;
		}
	}
}
