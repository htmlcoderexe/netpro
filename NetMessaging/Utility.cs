using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMessaging
{
    public static class Utility
    {
        /// <summary>
        /// Returns a sub-array.
        /// https://stackoverflow.com/a/943650/2699217
        /// </summary>
        /// <typeparam name="T">Type of the array's elements</typeparam>
        /// <param name="data">Source array</param>
        /// <param name="index">Source starting index</param>
        /// <param name="length">Number of elements to return</param>
        /// <returns>A subarray of the same type as the source.</returns>
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
