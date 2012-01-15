using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	public class MoveOrigin : TransformParent
	{
		double _moveX;
		double _moveY;
		bool _frameX;
		bool _frameY;

		public MoveOrigin()
		{
			_moveX = RandomNumberProvider.GetRandDouble() - 1.0;
			_moveY = RandomNumberProvider.GetRandDouble() - 1.0;

			_frameX = false;
			if (RandomNumberProvider.GetRandDouble() < 0.5)
			{
				_frameX = true;
			}
			_frameY = false;
			if (RandomNumberProvider.GetRandDouble() < 0.5)
			{
				_frameY = true;
			}
		}

		public override PointColor Transform(PointColor input)
		{
			input.X = input.X + _moveX;
			input.Y = input.Y + _moveY;

			return input;
		}

		public override void NextFrame(double percentChange)
		{
			if (_frameX)
			{
				_moveX += percentChange;
			}
			if (_frameY)
			{
				_moveY += percentChange;
			}
		}
	}
}