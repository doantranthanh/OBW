using System.ServiceModel;
using OrbusDevTest.DataAccess.OAService;

namespace OrbusDevTest.DataAccess.Codes
{
    public class WebServiceEndpointManager : IWebServiceEndpointManager
    {
        public OAServiceClient GetOaServiceClient()
        {
            var client = new OAServiceClient();

            client.Endpoint.Address = new EndpointAddress("http://localhost:36151/OAService.svc");
            return client;
        }
    }
}