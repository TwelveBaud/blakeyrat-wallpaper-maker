using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Jazzimage
{
	class Gradient
	{
		private SortedDictionary<double, DoubleColor> _segments = new SortedDictionary<double, DoubleColor>();

		/// <summary>
		/// Generate a random gradient
		/// </summary>
		public Gradient()
		{
			// Add beginning and end points
			_segments.Add(0.0, DoubleColor.GetRandomColorAlpha());
			_segments.Add(1.0, DoubleColor.GetRandomColorAlpha());

			// Determine number of intermediate points
			var loops = 1;
			var loopVal = RandomNumberProvider.GetDouble();

			while (loopVal < (0.75 / loops))
			{
				var newSegmentIndex = RandomNumberProvider.GetDouble();

				if (!_segments.ContainsKey(newSegmentIndex))
				{
					_segments.Add(newSegmentIndex, DoubleColor.GetRandomColorAlpha());
				}

				loops++;
			}
		}

		public DoubleColor GetColorAtValue(double value)
		{
			if (value < 0)
			{
				value = 0;
			}

			if (value > 1.0)
			{
				value = 1.0;
			}

			for (int i = 1; i < _segments.Count; i++)
			{
				if (_segments.ElementAt(i).Key > value)
				{
					var firstNum = _segments.ElementAt(i - 1).Key;
					var firstColor = _segments.ElementAt(i - 1).Value;
					var secondNum = _segments.ElementAt(i).Key;
					var secondColor = _segments.ElementAt(i).Value;

					var split = (value - firstNum) / (secondNum - firstNum);

					var r = (firstColor.R * (1 - split)) + (secondColor.R * split);
					var g = (firstColor.G * (1 - split)) + (secondColor.G * split);
					var b = (firstColor.B * (1 - split)) + (secondColor.B * split);
					var a = (firstColor.A * (1 - split)) + (secondColor.A * split);

					return new DoubleColor(r, g, b, a);
				}
			}

			return (_segments[1.0]);
		}
	}
}
