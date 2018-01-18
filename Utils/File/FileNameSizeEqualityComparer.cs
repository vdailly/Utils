using System.Collections.Generic;
using System.IO;


namespace Utils.File
{
    public class FileNameSizeEqualityComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(System.IO.FileInfo x, System.IO.FileInfo y)
        {
            if (x != null && y != null)
            {
                if (x.Name == y.Name &&
                    x.Length == y.Length)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetHashCode(System.IO.FileInfo obj)
        {
            int hash = 0;
            if (obj != null)
            {
                hash += obj.Name.GetHashCode();
            }
            return hash;
        }
    }
}
