using System;
using System.Collections.Generic;
using System.Text;
using Flurl;
using Flurl.Http;


namespace JohnsonControls.Metasys.BasicServices
{
    public class LegacyClient : ILegacyClient
    {
       /* public LegacyClient()
        {

        }

        private TraditionalClient traditionalClient;

        public int login(string username, string password, string hostname)
        {
            traditionalClient = new TraditionalClient();
            traditionalClient.TryLogin(username, password, hostname);
            return 0;
        }

        public int ReadProperty(string reference, string property, out string stringValue, out double rawValue, out string reliability, out string priority)
        {
            Guid fqr = GetObjectIdentifier(reference);
            ReadPropertyResult response = traditionalClient.ReadProperty(fqr, property);
            reliability = response.Reliability;
            stringValue = response.StringValue;
            priority = response.Priority;
            rawValue = response.NumericValue;
            return 0;
        }

        public int ReadPropertyMultiple(string reference, ref string[] objectList,
            ref string[] propertyList, out string[] valueList)
        {
            Guid fqr = GetObjectIdentifier(reference);
            <IEnumerable<ReadPropertyResult>>response = traditionalClient.ReadPropertyMultiple()

            return 0;
        }

        public Guid GetObjectIdentifier(string itemReference)
        {
            var response = client.Request("objectIdentifiers")
                .SetQueryParam("fqr", itemReference)
                .GetStringAsync();

            try
            {
                var id = new Guid(response.Result.Trim('"'));
                return id;
            }
            catch (System.FormatException)
            {
                return Guid.Empty;
            }
        }*/
    }
}
