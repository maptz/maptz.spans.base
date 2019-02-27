using System;
namespace Maptz.Spans
{public static class HashCodeHelpers
    {
        /// <summary>
        /// Combine hash codes.
        /// </summary>
        /// <param name="hashCodes"></param>
        /// <returns></returns>
        public static int Combine(params int[] hashCodes)
        {
            int hash1 = (5381 << 16) + 5381;
            int hash2 = hash1;

            int i = 0;
            foreach (var hashCode in hashCodes)
            {
                if (i % 2 == 0)
                    hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ hashCode;
                else
                    hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ hashCode;

                ++i;
            }

            return hash1 + (hash2 * 1566083941);
        }

    }
}