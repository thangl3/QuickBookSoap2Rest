using System.Threading.Tasks;

namespace QuickBookSoap2Rest.Interfaces
{
    public interface IWCWebMethodAsync
    {
        Task<string> serverVersionAsync(string strVersion);
        Task<string> clientVersionAsync(string strVersion);
        Task<string[]> authenticateAsync(string strUserName, string strPassword);
        Task<string> sendRequestXMLAsync(string ticket, string strHCPResponse, string strCompanyFileName, string qbXMLCountry, int qbXMLMajorVers, int qbXMLMinorVers);
        Task<int> receiveResponseXMLAsync(string ticket, string response, string hresult, string message);
        Task<string> connectionErrorAsync(string ticket, string hresult, string message);
        Task<string> getLastErrorAsync(string ticket);
        Task<string> closeConnectionAsync(string ticket);
    }
}
