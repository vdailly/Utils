using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.LDAP
{
    public class LDAPMapAttribute : Attribute
    {
        public string Name;
        public Type Type;
        public LDAPMapAttribute() { }
    }
}
