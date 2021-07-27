namespace Presentation.GraphQL.Base
{
    using System;
    using global::GraphQL.Types;
    using Microsoft.Extensions.DependencyInjection;
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

            Field(typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TDetection>>>),
                "createDetection",
                "Creates a detection",
                arguments: CreateDetectionArguments(),
                resolve: input => provider.GetService<Detection.Creating.IResolver>().Execute(input));

            Field(typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TCamera>>>),
                "registerCamera",
                "Register a camera",
                arguments: RegisterCameraArguments(),
                resolve: input => provider.GetService<Camera.Register.IResolver>().Execute(input));
        }

        private static QueryArguments CreateDetectionArguments() => new (new QueryArgument(
            typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TCreateDetection>>>))
        {
            Name = "input",
        });

        private static QueryArguments RegisterCameraArguments() => new (new QueryArgument(
            typeof(NonNullGraphType<ListGraphType<NonNullGraphType<TRegisterCamera>>>))
        {
            Name = "input",
        });
    }
}
