namespace Presentation.Camera.Fetching
{
    using System.Collections.Generic;
    using Business.Camera.Common.Models;
    using Business.Camera.Fetching.Commands;
    using Business.Camera.Fetching.Models;
    using Business.Pagination.Models;
    using global::GraphQL;

    public class Resolver : IResolver
    {
        private readonly IGetCameras _getCameras;

        public Resolver(IGetCameras getCameras) => _getCameras = getCameras;

        public MPagination<MCamera> Execute(IResolveFieldContext<object> input)
        {
            var parameter = input.GetArgument<PCamera>("parameter");
            return _getCameras.Execute(parameter);
        }
    }
}
