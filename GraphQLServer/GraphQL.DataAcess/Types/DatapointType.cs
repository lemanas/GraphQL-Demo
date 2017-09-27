using GraphQL.Domain;
using GraphQL.Net;

namespace GraphQL.DataAcess.Types
{
    public static class DatapointType
    {
        public static GraphQLTypeBuilder<ServerContext, Datapoint> AddFields(
            GraphQLTypeBuilder<ServerContext, Datapoint> datapoint)
        {
            datapoint.AddField(f => f.Year);
            datapoint.AddField(f => f.Salary);

            return datapoint;
        }
    }
}
