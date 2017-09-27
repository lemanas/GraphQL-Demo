using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace GraphQLServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
