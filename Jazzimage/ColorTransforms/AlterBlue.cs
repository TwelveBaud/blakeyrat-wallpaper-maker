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
			_amount = (RandomNumberProvider.GetRandDouble() * 1.5) + 0.5;
		}
		
		public override PointColor Transform(PointColor input)
		{
			input.Color = ColorUtils.CapColor(input.Color.A, input.Color.R, input.Color.G, Convert.ToInt32(Convert.ToDouble(input.Color.B) * _amount));
			
			return input;
		}
	}
}
