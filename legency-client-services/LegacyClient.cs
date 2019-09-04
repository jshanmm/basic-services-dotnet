using JohnsonControls.Metasys.BasicServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace legency_client_services
{
    [ComVisible(true)]
    [Guid("0261C5FD-2473-4EC1-A78C-31A5C27C8163")]
    [ClassInterface(ClassInterfaceType.None)]
    public class LegacyClient : ILegacyClient
    {

        private TraditionalClient traditionalClient;
        public LegacyClient()
        {
        }

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        public int login(string username, string password, string hostname)
        {
            traditionalClient = new TraditionalClient();
            traditionalClient.TryLogin(username, password, hostname);
            return 0;
        }

        /// <summary>
        /// Read one attribute value given the Guid of the object
        /// </summary>
        public int ReadProperty(string reference, string property, out string stringValue, out double rawValue, out string reliability, out string priority)
        {
            Guid fqr = traditionalClient.GetObjectIdentifier(reference);
            ReadPropertyResult response = traditionalClient.ReadProperty(fqr, property);
            reliability = response.Reliability;
            stringValue = response.StringValue;
            priority = response.Priority;
            rawValue = response.NumericValue;
            if (stringValue == "Unsupported Data Type")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Read multiple attribute value given the Guid of the object
        /// </summary>
        public int ReadPropertyMultiple(string reference, ref string[] objectList,
            ref string[] propertyList, out string[] valueList)
        {
            int readPropertyMutlipleResponse = 0;

            List<Guid> ObjectFqrList = new List<Guid>();
            foreach (string objects in objectList)
            {
                var fqr = traditionalClient.GetObjectIdentifier(objects);
                ObjectFqrList.Add(fqr);
            }
            IEnumerable<ReadPropertyResult> response = traditionalClient.ReadPropertyMultiple(ObjectFqrList, propertyList);

            //TO DO Implementation
            List<string> ValueList = new List<string>();
            ValueList.Add("1");
            ValueList.Add("2");
            valueList = ValueList.ToArray();
            //response.GetEnumerator()
            return readPropertyMutlipleResponse;
        }

        public int WriteProperty(string reference, string property, string newValue,
            string priority, out string status)
        {
            Guid fqr = traditionalClient.GetObjectIdentifier(reference);
            traditionalClient.WriteProperty(fqr, property, newValue);
            status = "OK";
            return 0;
        }

        public int SendCommand(string reference, string command, ref string[] parameters,
            string priority, out string status, out string[] returnParameters)
        {
            Guid fqr = traditionalClient.GetObjectIdentifier(reference);
            List<string> paramaterList = new List<string>();
            foreach (string parameter in parameters)
            {
                paramaterList.Add(parameter);
            }
            traditionalClient.SendCommand(fqr, command, paramaterList);
            status = "OK";

            //TO DO Implementation
            List<string> returnParameterList = new List<string>();
            returnParameterList.Add("1");
            returnParameterList.Add("2");
            returnParameters = returnParameterList.ToArray();
            return 0;
        }
    }
}
