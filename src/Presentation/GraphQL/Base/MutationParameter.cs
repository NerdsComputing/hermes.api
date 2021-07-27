namespace Presentation.GraphQL.Base
{
    using System;
    using global::GraphQL;
    using global::GraphQL.Types;

    public class MutationParameter
    {
        public string Name { get; }

        public ObjectGraphType TypeObject { get; }

        public string Description { get; }

        public Func<IResolveFieldContext<object>, object> Resolver { get; }

        public MutationParameter(string name, string description, Func<IResolveFieldContext<object>, object> resolver, ObjectGraphType objectGraphType)
        {
            Name = name;
            Description = description;
            Resolver = resolver;
            TypeObject = objectGraphType;
        }
    }
}
