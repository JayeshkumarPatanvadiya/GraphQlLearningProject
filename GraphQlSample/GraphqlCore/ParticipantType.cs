using GraphQL.Types;
using GraphQlSample.Infrastructure.DBContext;
using GraphQlSample.Infrastructure.Repositories;

namespace GraphQlSample.GraphqlCore
{
    public class ParticipantType : ObjectGraphType<Participant>
    {
        public ParticipantType(ITechEventRepository repository) 
        {
            Field(x => x.ParticipantId).Description("Participant id.");
            Field(x => x.ParticipantName).Description("Participant name.");
            Field(x => x.Email).Description("Participant Email address.");
            Field(x => x.Phone).Description("Participant phone number.");


            Field<ListGraphType<ParticipantType>>(
              "participants",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "participantId" }),
              resolve: context => repository.GetParticipantInfoByEventIdAsync(context.Source.ParticipantId)
           );
        }
    }
}
