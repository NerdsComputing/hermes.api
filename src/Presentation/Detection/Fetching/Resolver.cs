namespace Presentation.Detection.Fetching
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using Business.Detection.Fetching.Commands;
    using global::GraphQL;

    public class Resolver : IResolver
    {
        private readonly IGetDetection _getDetection;

        public Resolver(IGetDetection getDetection)
        {
            _getDetection = getDetection;
        }

        public IEnumerable<MDetection> Execute(IResolveFieldContext<object> input) =>
            _getDetection.Execute(new Nothing());
    }
}
