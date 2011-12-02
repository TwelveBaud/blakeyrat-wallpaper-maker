using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	public class SineX : TransformParent
	{
		protected double _amount;

		public SineX()
		{
			_amount = NumberUtils.GetRandDouble() * (2 * Math.PI);
		}

		public override PointColor Transform(PointColor input)
		{
			double inX = input.X;
			double inY = input.Y;

			double outX = inX + Math.Sin(inY * _amount) * 0.5;

			input.X = outX;
			input.Y = inY;

			return input;
		}

		public override void NextFrame(double percentChange)
		{
			_amount += percentChange * (2 * Math.PI);
		}
	}
}
