using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class GreyscaleY : TransformParent
	{
		double _alpha;

		public GreyscaleY()
		{
			_alpha = RandomNumberProvider.GetDouble();
		}

		public override PointColor Transform(PointColor input)
		{
			var inY = input.Y;

			inY = inY % 1.0;
			var greyVal = inY * 256.0;

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
