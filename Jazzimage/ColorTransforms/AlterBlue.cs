using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	public class AlterBlue : TransformParent
	{
		double _amount;

		public AlterBlue()
		{
			_amount = (RandomNumberProvider.GetDouble() * 1.5) + 0.5;
		}

		public override PointColor Transform(PointColor input)
		{
			input.Color = new DoubleColor(input.Color.R, input.Color.G, input.Color.B * _amount, input.Color.A);
			input.Color.NormalizeRGB();

			return input;
		}
	}
}
