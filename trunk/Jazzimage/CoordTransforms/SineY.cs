using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	public class SineY : TransformParent
	{
		protected double _amount;

		public SineY()
		{
			_amount = NumberUtils.GetRandDouble() * (2 * Math.PI);
		}

		public override PointColor Transform(PointColor input)
		{
			double inX = input.X;
			double inY = input.Y;

			double outY = inY + Math.Sin(inX * _amount) * 0.5;

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
