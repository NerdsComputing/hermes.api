namespace Presentation.Camera.Fetching
{
    using System.Collections.Generic;
    using Business.Camera.Common.Models;
    using Business.Camera.Fetching.Commands;
    using Business.Camera.Fetching.Models;
    using global::GraphQL;

    public class Resolver : IResolver
    {
        private readonly IGetCameras _getCameras;

        public Resolver(IGetCameras getCameras) => _getCameras = getCameras;

        public IEnumerable<MCamera> Execute(IResolveFieldContext<object> input)
        {
           return _getCameras.Execute(new PCamera());
        }
    }
}
