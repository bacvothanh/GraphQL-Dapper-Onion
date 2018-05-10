using System;
using System.Collections.Generic;
using System.Text;
using Fighting.Core.Models;
using GraphQL.Types;

namespace Fighting.GraphQL.Types
{
    public class ArenaGraphType : ObjectGraphType<Arena>
    {
        public ArenaGraphType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.AccountId);
            Field(x => x.StartTime);
            Field(x => x.IsDeleted);
            Field(x => x.Alias);
            Field(x => x.TimeCreatedOffset);
        }
    }
}
