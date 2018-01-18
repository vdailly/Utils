using System;
using System.Collections.Generic;

namespace Utils.Generic
{

    public class ProbabilisticComparer<T>
    {
        public List<Func<T, T, bool>> CompareFunctions = new List<Func<T, T, bool>>();

        public float Compare(T x, T y)
        {
            float result = 0;
            float i = 100 / (float)CompareFunctions.Count;

            if (x != null && y != null)
            {
                foreach(var f in CompareFunctions)
                {
                    try
                    {
                        if (f(x, y))
                        {
                            result += i;
                        }
                    } catch { }
                }
            }
            return result;
        }
    }
}
