using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	class ZoomOut : TransformParent
	{
		double _amount;

		public ZoomOut()
		{
			_amount = RandomNumberProvider.GetRandDouble() * 100;
		}

		public override PointColor Transform(PointColor input)
		{
			input.X = input.X / _amount;
			input.Y = input.Y / _amount;

			return input;
		}
	}
}
