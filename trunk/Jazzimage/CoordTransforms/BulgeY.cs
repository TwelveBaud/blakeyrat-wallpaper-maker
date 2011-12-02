using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	public class BulgeY : TransformParent
	{
		protected double _amount;

		public BulgeY()
		{
			_amount = NumberUtils.GetRandDouble() * 2.0;
		}

		public override PointColor Transform(PointColor input)
		{
			double inX = input.X - 0.5;
			double inY = input.Y - 0.5;

			double outY = inY * (inX * _amount);

			input.X = inX;
			input.Y = outY;

			return input;
		}

		public override void NextFrame(double percentChange)
		{
			_amount += percentChange * (2 * Math.PI);
		}
	}
}
