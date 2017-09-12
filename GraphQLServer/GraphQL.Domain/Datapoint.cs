using System;

namespace GraphQL.Domain
{
    public class Datapoint
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Year { get; set; }
        public double Salary { get; set; }
    }
}
