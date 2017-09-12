using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GraphQL.DataAcess;
using GraphQL.Domain;
using GraphQL.Net;
using Newtonsoft.Json;

namespace GraphQLServer.Controllers
{
    public class UsersController : ApiController
    {
        public string GetData()
        {
            var schema = GraphQL<ServerContext>.CreateDefaultSchema(() => new ServerContext());
            var user = schema.AddType<User>();
            var datapoint = schema.AddType<Datapoint>();

            user.AddField(f => f.Email);

            datapoint.AddField(f => f.Year);
            datapoint.AddField(f => f.Salary);

            schema.AddListField("users", db => db.Users);
            schema.AddField("user", new {id = 0}, (db, args) => db.Users.FirstOrDefault(u => u.Id == args.id));

            schema.AddField("datapoints", new {id = 0}, (db, args) => db.Datapoints.Where(p => p.UserId == args.id));

            schema.Complete();

            var query = @"{
            users
            }
            ";

            var gql = new GraphQL<ServerContext>(schema);
            var dict = gql.ExecuteQuery(query);
            return JsonConvert.SerializeObject(dict, Formatting.Indented);
        }
    }
}
