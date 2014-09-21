using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jazzimage
{
	static class RandomNumberProvider
	{
		private static Random _randGlobal = new Random();
		[ThreadStatic]
		private static Random _randLocal;

		static public double GetDouble()
		{
			Random rand = GetLocalRand();
			return rand.NextDouble();
		}

		static public int GetInt( int maxValue )
		{
			Random rand = GetLocalRand();
			return rand.Next(maxValue);
		}

		static private Random GetLocalRand()
		{
			Random rand = _randLocal;

			if (rand == null)
			{
				int seed;
				lock (_randGlobal)
				{
					seed = _randGlobal.Next();
				}
				_randLocal = rand = new Random(seed);
			}

			return rand;
		}
	}
}
