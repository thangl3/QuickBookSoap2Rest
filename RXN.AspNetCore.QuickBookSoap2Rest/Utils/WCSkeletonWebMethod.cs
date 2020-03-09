using System;
using System.Collections.Generic;
using System.Text;

namespace RXN.AspNetCore.QuickBookSoap2Rest.Utils
{
    public enum WCSkeletonWebMethod
    {
        ServerVersion = 0,
        ClientVersion = 1,
        Authenticate = 2,
        SendRequestXML = 3,
        ReceiveResponseXML = 4,
        ConnectionError = 5,
        GetLastError = 6,
        CloseConnection = 7,
        None = 8
    }
}
