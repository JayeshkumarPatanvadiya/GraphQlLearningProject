using GraphQL.Types;
using System.Collections.Generic;


namespace GraphQlSample.GraphqlCore.SchemaMapper
{
    public class SchemaMapper : ISchemaMapper
    {
        public Dictionary<string, ISchema> mappedSchema;
        public SchemaMapper(Dictionary<string, ISchema> mappedSchemas)
        {
            this.mappedSchema = mappedSchemas;
        }

        public ISchema GetSchema(string schema)
        {
            return mappedSchema[schema];
        }
    }
}
