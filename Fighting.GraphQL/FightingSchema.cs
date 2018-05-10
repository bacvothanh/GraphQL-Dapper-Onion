using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;
using GraphQL.Types;

namespace Fighting.GraphQL
{
    public class FightingSchema : Schema
    {
        public FightingSchema(IDependencyResolver resolver) : base(resolver)
        {
            
        }
    }
}
