using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.DataStructures
{
    public class Array<T>
    {
        public bool isInArray(T needle, T[] haystack)
        {
            foreach (T straw in haystack)
            {
                if (straw.Equals(needle))
                {
                    return true;
                }
            }
            return false;
        }

#if DOTNET4
        public T[ ] intersect( T[ ] a, T[ ] b )
        {
            HashSet<T> setA = new HashSet<T>( a );
            HashSet<T> setB = new HashSet<T>( b );

            IEnumerable<T> resultantSet = setA.Intersect( setB );

            return resultantSet.ToArray( );
        }
#endif
    }
}
