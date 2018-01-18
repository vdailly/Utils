using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Utils.Extension
{
    public static class IPAddressExt
    {
        public static long ToInt64(this IPAddress iPAddress)
        {
            return BitConverter.ToInt64(iPAddress.GetAddressBytes(), 0);
        }

        public static IPAddress FromInt64(this Int64 value)
        {
            return new IPAddress((long)value);
        }


    }
}
