using GraphQL.Types;
using GraphQlSample.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlSample.GraphqlCore
{
    public class EventParticipants : ObjectGraphType<EventParticipant>
    {

        public EventParticipants()
        {
            Field(x => x.EventParticipantId).Description("Event ParticipantId.");
            Field(x => x.EventId).Description("EventId.");
            Field(x => x.ParticipantId).Description("ParticipantId.");
            Field(x => x.Participant.ParticipantName).Description("ParticipantName.");
        }
    }
}
