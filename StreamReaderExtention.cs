using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CustomerDataUpdateSystem
{
    public static class StreamReaderExtention
    {
        public static string ReadLine(this StreamReader sr, string delimiter)
        {
            var sb = new StringBuilder();
            var buf = new char[1];
            var chars = new StringBuilder();
            var isLineEnd = false;
            int flg = 0;
            do
            {
                sr.Read(buf, 0, 1);
                sb.Append(buf);
                chars.Append(buf);

                if (!delimiter.StartsWith(chars.ToString()))
                {
                    chars.Clear();
                }
                else
                {
                    if (delimiter == chars.ToString()) isLineEnd = true;
                }

            } while (!sr.EndOfStream && !isLineEnd);

            if (isLineEnd) sb = sb.Remove(sb.Length - delimiter.Length, delimiter.Length);

            return sb.ToString();
        }
    }
}
