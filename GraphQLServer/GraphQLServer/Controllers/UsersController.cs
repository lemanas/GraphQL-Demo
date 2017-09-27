using System.Web.Http;
using GraphQL.DataAcess;
using GraphQL.Net;

namespace GraphQLServer.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        public object GetData([FromBody]string query)
        {
            var initializer = Schema.Instance;
            GraphQLSchema<ServerContext> schema = initializer.DatabaseSchema;

            var gql = new GraphQL<ServerContext>(schema);
            var dict = gql.ExecuteQuery(query);
            return dict;
        }
    }
}
