using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	class Swirl:TransformParent
	{
		double _amountMultiplier;

		public Swirl()
		{
			_amountMultiplier = RandomNumberProvider.GetDouble() * (2 * Math.PI);
		}
		
		public override PointColor Transform( PointColor input)
		{
			double inX = input.X - 0.5;
			double inY = input.Y - 0.5;

			double amount = (Math.Sqrt(Math.Pow(inX, 2.0) + Math.Pow(inY, 2.0))) * (2 * Math.PI);
			amount = amount * _amountMultiplier;

			double outX = inX * Math.Cos(amount) - inY * Math.Sin(amount);
			double outY = inX * Math.Sin(amount) + inY * Math.Cos(amount);

			input.X = outX + 0.5;
			input.Y = outY + 0.5;

			return input;
		}

		public override void NextFrame(double percentChange)
		{
			_amountMultiplier += percentChange * (2 * Math.PI);
		}
	}
}
