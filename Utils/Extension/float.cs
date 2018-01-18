using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Extension
{
    public static class Float
    {
        public static string ToPercentString(this float number, int precision)
        {
            string format = string.Format("{{0:P{0}}}", precision);
            return string.Format(format, number);
        }

        public static string ToPercentString(this float number)
        {
            return number.ToPercentString(1);
        }
    }
}
