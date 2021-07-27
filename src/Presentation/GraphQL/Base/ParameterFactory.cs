namespace Presentation.GraphQL.Base
{
    using System;
    using global::GraphQL.Types;
    using Microsoft.Extensions.DependencyInjection;

    public static class ParameterFactory
    {
        public static MutationParameter MakeDetection(ObjectGraphType mutation, IServiceProvider provider)
        {
            return new ("createDetection",
                "Creates a detection", input => provider.GetService<Detection.Creating.IResolver>().Execute(input), mutation);
        }

        public static MutationParameter MakeCamera(ObjectGraphType mutation, IServiceProvider provider)
        {
            return new ("registerCamera",
                "Register a camera",
                input => provider.GetService<Camera.Register.IResolver>().Execute(input), mutation);
        }
    }
}
