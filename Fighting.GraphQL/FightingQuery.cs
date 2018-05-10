using System;
using System.Collections.Generic;
using System.Text;
using Fighting.GraphQL.Types;
using Fighting.Service.Interfaces;
using GraphQL.Types;

namespace Fighting.GraphQL
{
    public class FightingQuery : ObjectGraphType<object>
    {
        public FightingQuery(IAccountService accountService, IArenaService arenaService)
        {
            Field<AccountGraphType>(
                "account",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => accountService.GetById<long>(context.GetArgument<int>("id")));

            Field<ArenaGraphType>(
                "arena",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => arenaService.GetById<long>(context.GetArgument<int>("id")));
        }
    }
}
