using OrbusDevTest.DataAccess.OAService;

namespace OrbusDevTest.DataAccess.Codes
{
    public interface IWebServiceEndpointManager
    {
        OAServiceClient GetOaServiceClient();
    }
}
