using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	public class AlterRed : TransformParent
	{
		double _amount;
		
		public AlterRed()
		{
			_amount = (RandomNumberProvider.GetDouble() * 1.5) + 0.5;
		}
		
		public override PointColor Transform(PointColor input)
		{
			input.Color = ColorUtils.CapColor(input.Color.A, Convert.ToInt32(Convert.ToDouble(input.Color.R) * _amount), input.Color.G, input.Color.B);

			return input;
		}
	}
}
