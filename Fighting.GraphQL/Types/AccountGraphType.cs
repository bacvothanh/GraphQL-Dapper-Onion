using System;
using System.Collections.Generic;
using System.Text;
using Fighting.Core.Models;
using Fighting.Service.Interfaces;
using GraphQL.Types;

namespace Fighting.GraphQL.Types
{
    public class AccountGraphType : ObjectGraphType<Account>
    {
        public AccountGraphType(IArenaService arenaService)
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Address);
            Field(x => x.Bithday);
            Field(x => x.IsDeleted);
            Field(x => x.Role);
            Field(x => x.Email);
            Field<ListGraphType<ArenaGraphType>>("Arenas",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => arenaService.GetByAccountId(context.Source.Id), description: "");
        }
    }
}
