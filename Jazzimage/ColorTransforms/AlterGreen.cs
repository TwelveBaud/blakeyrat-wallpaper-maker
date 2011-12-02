using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	public class AlterGreen : TransformParent
	{
		double _amount;
		
		public AlterGreen()
		{
			_amount = (NumberUtils.GetRandDouble() * 1.5) + 0.5;
		}
		
		public override PointColor Transform(PointColor input)
		{
			input.Color = ColorUtils.CapColor(input.Color.A, input.Color.R, Convert.ToInt32(Convert.ToDouble(input.Color.G) * _amount), input.Color.B);

			return input;
		}
	}
}
