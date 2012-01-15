using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	public class Rotate : TransformParent
	{
		protected double _amount;

		public Rotate()
		{
			_amount = RandomNumberProvider.GetRandDouble() * (2 * Math.PI);
		}
		
		public override PointColor Transform( PointColor input)
		{
			double inX = input.X - 0.5;
			double inY = input.Y - 0.5;

			double outX = inX * Math.Cos(_amount) - inY * Math.Sin(_amount);
			double outY = inX * Math.Sin(_amount) + inY * Math.Cos(_amount);

			input.X = outX + 0.5;
			input.Y = outY + 0.5;

			return input;
		}

		public override void NextFrame(double percentChange)
		{
			_amount += percentChange * (2 * Math.PI);
		}
	}
}
