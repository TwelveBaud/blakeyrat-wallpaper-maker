using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	static class NumberUtils
	{
		static Random _rand = new Random();

		static public double GetRandDouble()
		{
			double result;

			// Lock requires to make random number generation thread-safe
			lock (_rand)
			{
				result = _rand.NextDouble();
			}

			return result;
		}

		static public int GetRandInt( int maxValue )
		{
			int result;

			// Lock requires to make random number generation thread-safe
			lock (_rand)
			{
				result = _rand.Next(maxValue);
			}

			return result;
		}
	}
}
