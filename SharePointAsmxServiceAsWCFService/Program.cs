using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SharePointAsmxServiceAsWCFService
{
    class Program
    {
        static void Main(string[] args)
        {
            CallASMXAsWCF();
        }

        protected internal static void CallASMXAsWCF()
        {
            ListsService.ListsSoapClient _proxy = new ListsService.ListsSoapClient("ListsSoap");
            _proxy.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential();
            _proxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            XElement lists = _proxy.GetListCollection();
            var doc = XDocument.Parse(lists.ToString());

            var listsTitles = from lsts in doc.Descendants().Descendants()
                              select lsts.Attribute("Title");
            listsTitles.ToList().ForEach(attribute => Console.WriteLine(attribute.Value));                  
            Console.Read();
        }
    }
}

