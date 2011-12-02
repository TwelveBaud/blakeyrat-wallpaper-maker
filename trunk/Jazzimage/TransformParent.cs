using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	public class TransformParent
	{
		public virtual PointColor Transform(PointColor input)
		{
			return input;
		}

		public virtual void NextFrame(double percentChange)
		{
			// Do nothing
		}
	}
}
