using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlSample.GraphqlCore.SchemaMapper
{
   public interface ISchemaMapper
    {
        ISchema GetSchema(string schema);

    }
}
