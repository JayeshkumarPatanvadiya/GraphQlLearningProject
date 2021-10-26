using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlSample.GraphqlCore
{
    public class ParticipantInputType : InputObjectGraphType
    {
        public ParticipantInputType()
        {
            Name = "AddParticipantInput";
            Field<NonNullGraphType<StringGraphType>>("participantName");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("phone");
        }
    }
}
