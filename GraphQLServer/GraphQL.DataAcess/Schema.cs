using System.Linq;
using GraphQL.DataAcess.Types;
using GraphQL.Domain;
using GraphQL.Net;

namespace GraphQL.DataAcess
{
    public class Schema
    {
        private static Schema _instance;

        private Schema()
        {
            var schema = GraphQL<ServerContext>.CreateDefaultSchema(() => new ServerContext());

            var user = schema.AddType<User>();
            user = UserType.AddFields(user);

            var datapoint = schema.AddType<Datapoint>();
            datapoint = DatapointType.AddFields(datapoint);

            schema = AddFields(schema);
            schema.Complete();
            DatabaseSchema = schema;
        }

        public static Schema Instance => _instance ?? (_instance = new Schema());

        public GraphQLSchema<ServerContext> DatabaseSchema { get; }

        private GraphQLSchema<ServerContext> AddFields(GraphQLSchema<ServerContext> schema)
        {
            schema.AddListField("users", db => db.Users);
            schema.AddField("user", new { id = 0 }, (db, args) => db.Users.FirstOrDefault(u => u.Id == args.id));

            schema.AddListField("datapoints", new { id = 0 }, (db, args) => db.Datapoints.Where(p => p.UserId == args.id));

            return schema;
        }
    }
}
