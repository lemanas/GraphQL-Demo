using GraphQL.Domain;
using GraphQL.Net;

namespace GraphQL.DataAcess.Types
{
    public static class UserType
    {
        public static GraphQLTypeBuilder<ServerContext, User> AddFields(GraphQLTypeBuilder<ServerContext, User> user)
        {
            user.AddField(f => f.Email);
            user.AddField(f => f.Id);

            return user;
        }
    }
}
