using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.LDAP
{
    public enum DirectoryTransformTableOptions
    {
        ATTRIBUTEFIRST = 0x0,
        CLASSFIRST     = 0x1
    }

    public class DirectoryTransformTable
    {
        public DirectoryTransformTableOptions Options = DirectoryTransformTableOptions.ATTRIBUTEFIRST;
    }
}
