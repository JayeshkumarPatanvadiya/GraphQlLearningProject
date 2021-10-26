using System;
using GraphQL.Types;
using GraphQlSample.Infrastructure.DBContext;
using GraphQlSample.Infrastructure.Repositories;
using GraphQlSample.Models;

namespace GraphQlSample.GraphqlCore
{
    public class ParticipantMutation : ObjectGraphType<object>
    {

        public ParticipantMutation(ITechEventRepository repository)
        {
            Name = "TechParticipantMutation";

            FieldAsync<ParticipantType>(
                "createParticipantEvent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ParticipantInputType>> { Name = "techParticipantInput" }
                ),
                resolve: async context =>
                {
                    var techParticipantInput = context.GetArgument<NewParticipantRequest>("techParticipantInput");
                    return await repository.AddParticipantAsync(techParticipantInput);
                });
        }
    }
}
