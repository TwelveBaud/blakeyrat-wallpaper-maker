using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class GreyscaleX : TransformParent
	{
		double _alpha;

		public GreyscaleX()
		{
			_alpha = RandomNumberProvider.GetDouble();
		}

		public override PointColor Transform(PointColor input)
		{
			var inX = input.X;

			inX = inX % 1.0;
			var greyVal = inX * 256.0;

			if (greyVal < 0.0)
			{
				greyVal = 0;
			};
			if (greyVal > 1.0)
			{
				greyVal = 1.0;
			};

			input.Color = new DoubleColor(greyVal, greyVal, greyVal, _alpha);

			return input;
		}
	}
}
