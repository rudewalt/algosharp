using System.Collections.Generic;
using System.Linq;

namespace Algosharp.Sorting.Tests
{
    public class SortTestsBase
    {
        public static IEnumerable<object[]> SortData
        {
            get
            {
                yield return new object[] { new[] { 5, 70, 5, 11, 1, 23, 78 } };
                yield return new object[] { new[] { 15, 80, 15, 21, 10, 33, 88, 26 } };
                yield return new object[] { new[] { -5, -70, -5, -11, -1, -23, -78 } };
                yield return new object[] { new[] { -15, -80, -15, -21, -10, -33, -88, -26 } };
                yield return new object[] { new[] { -5, 70, -5, -11, 1, 23, -78 } };
                yield return new object[] { new[] { 15, -80, -15, 21, -10, -33, 88, 26 } };
                yield return new object[] { new[] { 100 } };
                yield return new object[] { new int[0] };
                yield return new object[] { Enumerable.Range(1, 10000).OrderByDescending(x => x).ToArray() };
            }
        }
    }
}
