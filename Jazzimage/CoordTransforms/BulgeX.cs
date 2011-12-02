using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	public class BulgeX : TransformParent
	{
		protected double _amount;

		public BulgeX()
		{
			_amount = NumberUtils.GetRandDouble() * 2.0;
		}

		public override PointColor Transform(PointColor input)
		{
			double inX = input.X - 0.5;
			double inY = input.Y - 0.5;

			double outX = inX * (inY * _amount);

			input.X = outX + 0.5;
			input.Y = inY + 0.5;

			return input;
		}

		public override void NextFrame(double percentChange)
		{
			_amount += percentChange * (2 * Math.PI);
		}
	}
}
