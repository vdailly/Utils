using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.Protocols;

namespace Utils.LDAP
{
    public class DirectoryAttributeModificationEqualityComparer : IEqualityComparer<DirectoryAttributeModification>
    {
        public static DirectoryAttributeModificationEqualityComparer Instance =
            new DirectoryAttributeModificationEqualityComparer();

        public bool Equals(DirectoryAttributeModification x, DirectoryAttributeModification y)
        {
            if (x != null && y != null)
            {
                return x.Name == y.Name && x.Operation == y.Operation;
            }
            return false;
        }

        public int GetHashCode(DirectoryAttributeModification obj)
        {
            if (obj != null && !string.IsNullOrEmpty(obj.Name))
            {
                return obj.Name.GetHashCode();
            }
            return 0;
        }
    }
}
