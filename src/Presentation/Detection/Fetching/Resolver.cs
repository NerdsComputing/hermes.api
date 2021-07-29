namespace Presentation.Detection.Fetching
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using Business.Detection.Fetching.Commands;
    using Business.Detection.Fetching.Models;
    using Business.Pagination.Models;
    using global::GraphQL;

    public class Resolver : IResolver
    {
        private readonly IGetDetection _getDetection;

        public Resolver(IGetDetection getDetection) => _getDetection = getDetection;

        public MPagination<MDetection> Execute(IResolveFieldContext<object> input)
        {
            var parameter = input.GetArgument<PDetection>("parameter");
            return _getDetection.Execute(parameter);
        }
    }
}
