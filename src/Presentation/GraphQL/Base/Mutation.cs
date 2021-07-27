namespace Presentation.GraphQL.Base
{
    using System;
    using global::GraphQL.Types;
    using Presentation.Camera.Common.Types;
    using Presentation.Camera.Register.Types;
    using Presentation.Detection.Common.Types;
    using Presentation.Detection.Creating.Types;

    public class Mutation : ObjectGraphType
    {
        public Mutation(IServiceProvider provider)
        {
            Name = "mutation";
            Description = "All the mutations that can be done.";

            MutationFactory<TCreateDetection, TDetection>.Make(ParameterFactory.MakeDetection(this, provider));
            MutationFactory<TRegisterCamera, TCamera>.Make(ParameterFactory.MakeCamera(this, provider));
        }
    }
}
