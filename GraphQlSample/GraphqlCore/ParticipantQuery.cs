using GraphQL.Types;
using GraphQlSample.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlSample.GraphqlCore
{
    public class ParticipantQuery  : ObjectGraphType<object>
    {
        public ParticipantQuery(ITechEventRepository repository)
        {
            Name = "TechEventQuery";

            Field<TechEventInfoType>(
               "event",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "eventId" }),
               resolve: context => repository.GetTechEventByIdAsync(context.GetArgument<int>("eventId"))
            );

            Field<ListGraphType<TechEventInfoType>>(
             "events",
             resolve: context => repository.GetTechEventsAsync()
          );

            Field<ListGraphType<ParticipantType>>(
           "participant",
           resolve: context => repository.GetTechParticipantAsync()
        );

            Field<ListGraphType<EventParticipants>>(
          "eventparticipants",
          resolve: context => repository.GetTechEventParticipantAsync()
       );
        }

    }
}
