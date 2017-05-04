using System;
using System.Threading;

namespace Algosharp.Common.Helpers
{
	public class ThreadSafeRandom
	{
		private static int _seed = Environment.TickCount;

		private static readonly ThreadLocal<Random> Random =
			new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref _seed)));

		public static int Next() => Random.Value.Next();

		public static int Next(int maxValue) => Random.Value.Next(maxValue);

		public static int Next(int minValue, int maxValue) => Random.Value.Next(minValue, maxValue);
	}
}
