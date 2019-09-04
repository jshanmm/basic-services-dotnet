﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace legency_client_services
{
    [ComVisible(true)]
    [Guid("B1AF1A67-42A0-4E4A-8A07-97AA53B42D02")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ILegacyClient
    {
        int login(string username, string password, string hostname);
        int ReadProperty(string reference, string property, out string stringValue,
            out double rawValue, out string reliability, out string priority);
        int ReadPropertyMultiple(string reference, ref string[] objectList,
            ref string[] propertyList, out string[] valueList);
        int WriteProperty(string reference, string property, string newValue,
            string priority, out string status);
        int SendCommand(string reference, string command, ref string[] parameters,
            string priority, out string status, out string[] returnParameters);
    }
}