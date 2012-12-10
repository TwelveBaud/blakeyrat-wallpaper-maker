using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
    class GreyscaleX : TransformParent
    {
        int _alpha;

        public GreyscaleX()
        {
            _alpha = RandomNumberProvider.GetInt(256);
        }

        public override PointColor Transform(PointColor input)
        {
            double inX = input.X;

            inX = inX % 1.0;
            int greyVal = Convert.ToInt32( inX * 256 );

            if( greyVal < 0 )
            {
                greyVal = 0;
            };
            if( greyVal > 255 )
            {
                greyVal = 255;
            };

            input.Color = Color.FromArgb(_alpha, greyVal, greyVal, greyVal);

            return input;
        }
    }
}
