using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.Protocols;

namespace Utils.LDAP
{
    public class DirectorySchemaAttribute
    {

        [LDAPMap(Name = "DistinguishedName", Type = typeof(string))]
        public string DN;
        public string DisplayName;

        internal DirectorySchemaAttribute() { }
        internal DirectorySchemaAttribute(SearchResultEntry searchResultEntry)
        {

        }

        private void Initialize(SearchResultEntry searchResultEntry)
        {
            var LDAPMaps = (LDAPMapAttribute[])typeof(DirectorySchemaAttribute).GetCustomAttributes(typeof(LDAPMapAttribute), true);
            if (LDAPMaps.Length > 0)
            {

            }
        }
    }
}
