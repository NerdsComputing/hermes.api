namespace Presentation.GraphQL.Base
{
    using System;
    using global::GraphQL.Types;

    public sealed class Mutation : ObjectGraphType
    {
        public Mutation(IServiceProvider provider)
        {
            Name = "mutation";
            Description = "All the mutations that can be done.";

            AddField(Detection.Creating.Factory.Make(provider));
            AddField(Camera.Register.Factory.Make(provider));
        }
    }
}
