using System;
using System.Collections;
using System.Collections.Generic;

namespace Unit9
{
    public class TriangleComparer : IComparer<Triangle>
    {
        public int Compare(Triangle t1, Triangle t2)
        {
            if (t1 == null || t2 ==null)
                throw new ArgumentNullException("Comparable objects cannot be null.");

            var difference = t1.Square() - t2.Square();
            
            if (difference > 0)
            {
                return 1;
            }

            if (difference < 0)
            {
                return -1;
            }
               
            return 0;
        }
    }
}