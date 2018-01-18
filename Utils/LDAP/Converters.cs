using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.LDAP
{
    public class Converters
    {
        public static string Normalize(string attributeName)
        {
            if (attributeName.Contains(":"))
            {
                return attributeName.Split(':')[0];
            }
            return attributeName;
        }

        public static Tuple<Type, Func<object, string>, Func<string, object>> Default =
            new Tuple<Type, Func<object, string>, Func<string, object>>(
                typeof(string),
                (o) => (string)o,
                (s) => s
            );

        Dictionary<string, Tuple<Type, Func<object, string>, Func<string, object>>>
            converters = new Dictionary<string, Tuple<Type, Func<object, string>, Func<string, object>>>()
            {
                { "objectsid",
                    new Tuple<Type, Func<object, string>, Func<string, object>>(
                        typeof(byte[]), 
                        (o) => { return UTF8Encoding.UTF8.GetString((byte[])o); }, 
                        (s) => { return UTF8Encoding.UTF8.GetBytes(s); }
                    )
                },
                { "objectguid",
                    new Tuple<Type, Func<object, string>, Func<string, object>>(
                        typeof(byte[]),
                        (o) => { return ((Guid)o).ToString(); },
                        (s) => { return new Guid(s); }
                    )
                }
            };

        public Tuple<Type, Func<object, string>, Func<string, object>> GetConverter(DirectoryAttribute directoryAttribute)
        {
            if (directoryAttribute != null && converters.ContainsKey(directoryAttribute.Name))
            {
                return converters[directoryAttribute.Name];
            }
            return Converters.Default;
        }
    }
}
