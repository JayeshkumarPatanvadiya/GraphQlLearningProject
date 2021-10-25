using GraphQL;
using GraphQL.Types;
//using System.Web.Mvc;
//using System.Web.Mvc;
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
