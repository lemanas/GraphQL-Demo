using System.Data.Entity;
using GraphQL.Domain;

namespace GraphQL.DataAcess
{
    public class ServerContext : DbContext
    {
        public ServerContext() : base("name=ServerDb")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Datapoint> Datapoints { get; set; }
    }
}
