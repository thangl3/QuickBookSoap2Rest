using System;
using System.Collections.Generic;
using System.Text;

namespace RXN.AspNetCore.QuickBookSoap2Rest.Interfaces
{
    public interface IWCWebMethod
    {
        ///// <summary>
        ///// WebMethod - getInteractiveURL()
        ///// 
        ///// Signature: public string getInteractiveURL(string wcTicket, string sessionID)
        /////
        ///// IN: 
        ///// string wcTicket
        ///// string sessionID
        /////
        ///// OUT: 
        ///// URL string 
        ///// Possible values: 
        ///// URL to a website
        ///// </summary>
        //string getInteractiveURL(string wcTicket, string sessionID);
        ///// <summary>
        ///// WebMethod - interactiveRejected()
        ///// 
        ///// Signature: public string interactiveRejected(string wcTicket, string reason)
        /////
        ///// IN: 
        ///// string wcTicket
        ///// string reason
        /////
        ///// OUT: 
        ///// string 
        ///// </summary>
        //string interactiveRejected(string wcTicket, string reason);
        /// <summary>
        /// WebMethod - closeConnection()
        /// At the end of a successful update session, QBWebConnector will call this web method.
        /// Signature: public string closeConnection(string ticket)
        /// 
        /// IN:
        /// string ticket 
        /// 
        /// OUT:
        /// string closeConnection result 
        /// </summary>
        string serverVersion(string strVersion);
        /// <summary>
        /// WebMethod - closeConnection()
        /// At the end of a successful update session, QBWebConnector will call this web method.
        /// Signature: public string closeConnection(string ticket)
        /// 
        /// IN:
        /// string ticket 
        /// 
        /// OUT:
        /// string closeConnection result 
        /// </summary>
        string clientVersion(string strVersion);
        /// <summary>
        /// WebMethod - authenticate()
        /// To verify username and password for the web connector that is trying to connect
        /// Signature: public string[] authenticate(string strUserName, string strPassword)
        /// 
        /// IN: 
        /// string strUserName 
        /// string strPassword
        ///
        /// OUT: 
        /// string[] authReturn
        /// Possible values: 
        /// string[0] = ticket
        /// string[1]
        /// - empty string = use current company file
        /// - "none" = no further request/no further action required
        /// - "nvu" = not valid user
        /// - any other string value = use this company file
        /// </summary>
        string[] authenticate(string strUserName, string strPassword);
        /// <summary>
        /// WebMethod - sendRequestXML()
        /// Signature: public string sendRequestXML(string ticket, string strHCPResponse, string strCompanyFileName, 
        /// string Country, int qbXMLMajorVers, int qbXMLMinorVers)
        /// 
        /// IN: 
        /// int qbXMLMajorVers
        /// int qbXMLMinorVers
        /// string ticket
        /// string strHCPResponse 
        /// string strCompanyFileName 
        /// string Country
        /// int qbXMLMajorVers
        /// int qbXMLMinorVers
        ///
        /// OUT:
        /// string request
        /// Possible values: 
        /// - any_string = Request XML for QBWebConnector to process
        /// - "" = No more request XML 
        /// </summary>
        string sendRequestXML(string ticket, string strHCPResponse, string strCompanyFileName, string qbXMLCountry, int qbXMLMajorVers, int qbXMLMinorVers);
        /// <summary>
        /// WebMethod - receiveResponseXML()
        /// Signature: public int receiveResponseXML(string ticket, string response, string hresult, string message)
        /// 
        /// IN: 
        /// string ticket
        /// string response
        /// string hresult
        /// string message
        ///
        /// OUT: 
        /// int retVal
        /// Greater than zero  = There are more request to send
        /// 100 = Done. no more request to send
        /// Less than zero  = Custom Error codes
        /// </summary>
        int receiveResponseXML(string ticket, string response, string hresult, string message);
        /// <summary>
        /// WebMethod - connectionError()
        /// To facilitate capturing of QuickBooks error and notifying it to web services
        /// Signature: public string connectionError (string ticket, string hresult, string message)
        ///
        /// IN: 
        /// string ticket = A GUID based ticket string to maintain identity of QBWebConnector 
        /// string hresult = An HRESULT value thrown by QuickBooks when trying to make connection
        /// string message = An error message corresponding to the HRESULT
        ///
        /// OUT:
        /// string retVal
        /// Possible values: 
        /// - done = no further action required from QBWebConnector
        /// - any other string value = use this name for company file
        /// </summary>
        string connectionError(string ticket, string hresult, string message);
        /// <summary>
        /// WebMethod - getLastError()
        /// Signature: public string getLastError(string ticket)
        /// 
        /// IN:
        /// string ticket
        /// 
        /// OUT:
        /// string retVal
        /// Possible Values:
        /// Error message describing last web service error
        /// </summary>
        string getLastError(string ticket);
        /// <summary>
        /// WebMethod - closeConnection()
        /// At the end of a successful update session, QBWebConnector will call this web method.
        /// Signature: public string closeConnection(string ticket)
        /// 
        /// IN:
        /// string ticket 
        /// 
        /// OUT:
        /// string closeConnection result 
        /// </summary>
        string closeConnection(string ticket);
	}
}
