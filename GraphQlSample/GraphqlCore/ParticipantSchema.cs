using GraphQL;
using GraphQL.Types;

namespace GraphQlSample.GraphqlCore
{
    public class ParticipantSchema : Schema
    {
        public ParticipantSchema(IDependencyResolver resolver)
        {
            Query = resolver.Resolve<ParticipantQuery>();
            Mutation = resolver.Resolve<ParticipantMutation>();
            DependencyResolver = resolver;
        }
    }
}
