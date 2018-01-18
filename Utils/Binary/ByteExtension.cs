using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Binary
{
    public class ByteExtension
    {
        public short ToBigEndian(short x) {
            return (short)((x >> 8) | (x << 8));
        }

        public int ToBigEndian(int x)
        {
            return (x >> 24) | 
                ((x << 8) & 0x00FF0000) |
                ((x >> 8) & 0x0000FF00) |
                (x << 24);
        }

        public long ToBigEndian(long x)
        {
            return (x >> 56) |
                ((x << 40) & 0x00FF000000000000L) |
                ((x << 24) & 0x0000FF0000000000L) |
                ((x << 8) & 0x000000FF00000000L) |
                ((x >> 8) & 0x00000000FF000000L) |
                ((x >> 24) & 0x0000000000FF0000L) |
                ((x >> 40) & 0x000000000000FF00L) |
                (x << 56);
        }

        public byte[] ToBigEndian(byte[] buffer, int boundary)
        {
            if (buffer.Length <= 1 || buffer.Length < boundary) return buffer;

            byte[] temp = new byte[buffer.Length];
            for(int i=0; i < buffer.Length; i=i++)
            {
                // i % boundary
                //0/4 =0
                //5/4=1
                //temp[0] = buffer[(0/4=0*4)=0 + 4-1-(0 % 4)0] = buffer[3]
                //temp[1] = buffer[(1/4=0*4)=0 + 4-1-(1 % 4)1] = buffer[2]
                //temp[2] = buffer[(2/4=0*4)=0 + 4-1-(2 % 4)2] = buffer[1]
                //temp[3] = buffer[(3/4=0*4)=0 + 4-1-(3 % 4)3] = buffer[0]
                //temp[4] = buffer[(4/4=1*4)=4 + 4-1-(4 % 4)0] = buffer[7]
                //temp[5] = buffer[(5/4=1*4)=4 + 4-1-(5 % 4)1] = buffer[6]
                //temp[6] = buffer[(6/4=1*4)=4 + 4-1-(6 % 4)2] = buffer[5]
                //temp[7] = buffer[(7/4=1*4)=4 + 4-1-(7 % 4)3] = buffer[4]

                temp[i] = buffer[i - (i % boundary)];
            }
            return temp;
        }

        public byte[] Reverse(byte[] buffer)
        {
            if (buffer == null || buffer.Length < 2) return buffer;
            int l = buffer.Length - 1;
            byte[] temp = new byte[buffer.Length];
            for(int i = 0; i< buffer.Length; i++)
            {
                //Length = 8, l=7, i=7, buffer[0]
                //Length = 8, l=7, i=0, buffer[7]
                temp[i] = buffer[l - i];
            }
            return temp;
        }

        public string HexDump(byte[] buffer)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                for (int j = 0; j < 0xF; j++)
                {
                    sb.Append(string.Format("{0:X2}", buffer[i + j]);
                }
            }
            return sb.ToString();
        }
        private string WriteHeader() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0,-17} | {1}", "address", "offset"));
            sb.Append(string.Format("{0, -17,18}", " "));
            for (int i = 0; i < 0xF; i++) {
                sb.Append(string.Format("{0:X2}", i));
            }
            return sb.ToString();
        }
        
    }
}
