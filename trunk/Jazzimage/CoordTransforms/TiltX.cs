using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
    class TiltX : TransformParent
    {
        double _amount;
        
        public TiltX()
        {
            _amount = RandomNumberProvider.GetRandDouble();
        }

        public override PointColor Transform(PointColor input)
        {
            input.X = input.X + (input.Y * _amount);

            return input;
        }
    }
}
