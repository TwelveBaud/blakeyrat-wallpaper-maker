using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	static class RandomNumberProvider
	{
		static Random _rand = new Random();

		static public double GetDouble()
		{
			double result;

			// Lock requires to make random number generation thread-safe
			lock (_rand)
			{
				result = _rand.NextDouble();
			}

			return result;
		}

		static public int GetInt( int maxValue )
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
