using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.Protocols;

namespace Utils.LDAP
{
    public delegate void DirectoryObjectEventHandler(object sender, EventArgs e);

    public class DirectoryObject
    {

        private DirectoryConnection _directoryConnection;
        private HashSet<DirectoryAttribute> _directoryAttributes;

        internal DirectoryObject() {}
        internal DirectoryObject(SearchResultEntry searchResultEntry) {

        }

        public void Add(DirectoryAttribute directoryAttribute)
        {

        }

        public void Remove(DirectoryAttribute directoryAttribute)
        {

        }

        public void Create() { }
        public void Update() { }
        public void Delete() { }
    }
}
