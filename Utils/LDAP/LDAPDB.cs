using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.Protocols;
using System.Data;

namespace Utils.LDAP
{
    public class LDAPDB
    {
        private DataTable dataTable;
        public LDAPDB() {
            dataTable = new DataTable();
            CreateColumn("DistinguishedName");
            dataTable.AcceptChanges();
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };
        }

        public void Add(SearchResultEntry searchResultEntry)
        {
            if (searchResultEntry != null)
            {
                DataRow row = dataTable.NewRow();
                row.BeginEdit();
                foreach (string attribute in searchResultEntry.Attributes.AttributeNames)
                {
                    DataColumn dataColumn = null;
                    if (!dataTable.Columns.Contains(attribute))
                    {
                        dataColumn = CreateColumn(attribute);
                    } else
                    {

                    }

                    row[dataColumn] = 
                }
                row.SetAdded();
                row.EndEdit();

            }
        }

        internal void CreateColumn(string attributeName) {
            dataTable.Columns.Add(
                new DataColumn(attributeName, typeof(string))
            );
        }

        public void Export(IExporter exporter)
        {
            exporter.Export(this);
        }
    }
}

