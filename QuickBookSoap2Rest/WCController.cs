using Microsoft.AspNetCore.Http;
using QuickBookSoap2Rest.Helpers;
using QuickBookSoap2Rest.Interfaces;
using QuickBookSoap2Rest.Utils;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuickBookSoap2Rest
{
    public class WCController
    {
        private readonly IWCWebMethod _hanlder;
        private readonly IWCWebMethodAsync _hanlderAsync;

        /// <summary>
        /// 
        /// Recieved your custom handler implemented from IWCWebMethod
        /// 
        /// </summary>
        /// <param name="hanlder"></param>
        public WCController(IWCWebMethod hanlder)
        {
            _hanlder = hanlder;
        }

        public WCController(IWCWebMethodAsync hanlderAsync)
        {
            _hanlderAsync = hanlderAsync;
        }

        /// <summary>
        /// Listen all the request from Web Connector of QuickBooks and control them to your handler
        /// </summary>
        /// <returns></returns>
        public XElement Handle(HttpRequest request)
        {
            var s2r = new WCRequestBridge(request);
            var soapAction = s2r.GetSkeletonMethod();

            object responeValue;

            switch (soapAction)
            {
                case WCSkeletonWebMethod.ServerVersion:
                    responeValue = _hanlder.serverVersion(s2r.GetParam(WC_REQUEST_PARAMS.VERSION));
                    break;

                case WCSkeletonWebMethod.ClientVersion:
                    responeValue = _hanlder.clientVersion(s2r.GetParam(WC_REQUEST_PARAMS.VERSION));
                    break;

                case WCSkeletonWebMethod.Authenticate:
                    responeValue = _hanlder.authenticate(
                        s2r.GetParam(WC_REQUEST_PARAMS.AUTH_USERNAME),
                        s2r.GetParam(WC_REQUEST_PARAMS.AUTH_PASSWORD)
                    );
                    break;

                case WCSkeletonWebMethod.SendRequestXML:
                    responeValue = _hanlder.sendRequestXML(
                        s2r.GetParam(WC_REQUEST_PARAMS.TICKET),
                        s2r.GetParam(WC_REQUEST_PARAMS.HCP_RESPONSE),
                        s2r.GetParam(WC_REQUEST_PARAMS.COMPANY_FILENAME),
                        s2r.GetParam(WC_REQUEST_PARAMS.XML_COUNTRY),
                        int.Parse(s2r.GetParam(WC_REQUEST_PARAMS.XML_MAJOR_VERS)),
                        int.Parse(s2r.GetParam(WC_REQUEST_PARAMS.XML_MINOR_VERS))
                    );
                    break;

                case WCSkeletonWebMethod.ReceiveResponseXML:
                    responeValue = _hanlder.receiveResponseXML(
                        s2r.GetParam(WC_REQUEST_PARAMS.TICKET),
                        s2r.GetParam(WC_REQUEST_PARAMS.RESPONSE),
                        s2r.GetParam(WC_REQUEST_PARAMS.H_RESULT),
                        s2r.GetParam(WC_REQUEST_PARAMS.MESSAGE)
                    );
                    break;

                case WCSkeletonWebMethod.ConnectionError:
                    responeValue = _hanlder.connectionError(
                        s2r.GetParam(WC_REQUEST_PARAMS.TICKET),
                        s2r.GetParam(WC_REQUEST_PARAMS.H_RESULT),
                        s2r.GetParam(WC_REQUEST_PARAMS.MESSAGE)
                    );
                    break;

                case WCSkeletonWebMethod.GetLastError:
                    responeValue = _hanlder.getLastError(s2r.GetParam(WC_REQUEST_PARAMS.TICKET));
                    break;

                case WCSkeletonWebMethod.CloseConnection:
                    responeValue = _hanlder.closeConnection(s2r.GetParam(WC_REQUEST_PARAMS.TICKET));
                    break;

                default:
                    return null;
            }

            var resBridge = new WCResponseBridge(soapAction, responeValue);

            return resBridge.ResponseXml();
        }

        public async Task<XElement> HandleAsync(HttpRequest request)
        {
            var s2r = new WCRequestBridge(request);
            var soapAction = s2r.GetSkeletonMethod();

            object responeValue;

            switch (soapAction)
            {
                case WCSkeletonWebMethod.ServerVersion:
                    responeValue = await _hanlderAsync.serverVersionAsync(s2r.GetParam(WC_REQUEST_PARAMS.VERSION));
                    break;

                case WCSkeletonWebMethod.ClientVersion:
                    responeValue = await _hanlderAsync.clientVersionAsync(s2r.GetParam(WC_REQUEST_PARAMS.VERSION));
                    break;

                case WCSkeletonWebMethod.Authenticate:
                    responeValue = await _hanlderAsync.authenticateAsync(
                        s2r.GetParam(WC_REQUEST_PARAMS.AUTH_USERNAME),
                        s2r.GetParam(WC_REQUEST_PARAMS.AUTH_PASSWORD)
                    );
                    break;

                case WCSkeletonWebMethod.SendRequestXML:
                    responeValue = await _hanlderAsync.sendRequestXMLAsync(
                        s2r.GetParam(WC_REQUEST_PARAMS.TICKET),
                        s2r.GetParam(WC_REQUEST_PARAMS.HCP_RESPONSE),
                        s2r.GetParam(WC_REQUEST_PARAMS.COMPANY_FILENAME),
                        s2r.GetParam(WC_REQUEST_PARAMS.XML_COUNTRY),
                        int.Parse(s2r.GetParam(WC_REQUEST_PARAMS.XML_MAJOR_VERS)),
                        int.Parse(s2r.GetParam(WC_REQUEST_PARAMS.XML_MINOR_VERS))
                    );
                    break;

                case WCSkeletonWebMethod.ReceiveResponseXML:
                    responeValue = await _hanlderAsync.receiveResponseXMLAsync(
                        s2r.GetParam(WC_REQUEST_PARAMS.TICKET),
                        s2r.GetParam(WC_REQUEST_PARAMS.RESPONSE),
                        s2r.GetParam(WC_REQUEST_PARAMS.H_RESULT),
                        s2r.GetParam(WC_REQUEST_PARAMS.MESSAGE)
                    );
                    break;

                case WCSkeletonWebMethod.ConnectionError:
                    responeValue = await _hanlderAsync.connectionErrorAsync(
                        s2r.GetParam(WC_REQUEST_PARAMS.TICKET),
                        s2r.GetParam(WC_REQUEST_PARAMS.H_RESULT),
                        s2r.GetParam(WC_REQUEST_PARAMS.MESSAGE)
                    );
                    break;

                case WCSkeletonWebMethod.GetLastError:
                    responeValue = await _hanlderAsync.getLastErrorAsync(s2r.GetParam(WC_REQUEST_PARAMS.TICKET));
                    break;

                case WCSkeletonWebMethod.CloseConnection:
                    responeValue = await _hanlderAsync.closeConnectionAsync(s2r.GetParam(WC_REQUEST_PARAMS.TICKET));
                    break;

                default:
                    return null;
            }

            var resBridge = new WCResponseBridge(soapAction, responeValue);

            return resBridge.ResponseXml();
        }
    }
}
