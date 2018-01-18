using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.Protocols;

namespace Utils.LDAP
{
    public class DirectoryConnection
    {
        private LdapDirectoryIdentifier _identifier;
        private LdapConnection _connection;

        private bool VerifyServerCertificate(LdapConnection connection) {
            return true;
        }

        public async Task SendAsync()
        {
            TaskFactory factory = new TaskFactory();
            await factory.FromAsync<IEnumerable<SearchResultEntry>>(
                Begin, End, null, TaskCreationOptions.AttachedToParent
            );
        }

        private IAsyncResult Begin(AsyncCallback asyncCallback, object state)
        {
            return _connection.BeginSendRequest(null, PartialResultProcessing.NoPartialResultSupport, asyncCallback, state);
        }

        private void InnerCallback(IAsyncResult asyncResult) {
            SendAsync().Wait();
        }

        private IEnumerable<SearchResultEntry> End(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }
    }
}
