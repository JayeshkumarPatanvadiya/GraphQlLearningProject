using GraphQL;
using GraphQL.Types;
namespace GraphQlSample.GraphqlCore
{
    public class TechEventSchema : Schema
    {
        public TechEventSchema(IDependencyResolver resolver)
        {
            Query = resolver.Resolve<TechEventQuery>();
            Mutation = resolver.Resolve<TechEventMutation>();

            DependencyResolver = resolver;
        }
    }
}
