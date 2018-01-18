using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.LDAP
{
    public abstract class DirectoryTransform
    {
        public abstract bool IsValid(DirectoryObject directoryObject);
    }
}
