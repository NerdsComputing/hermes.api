namespace Presentation.Detection.Creating
{
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using Business.Detection.Creating.Commands;
    using Business.Detection.Creating.Models;
    using global::GraphQL;

    public class Resolver : IResolver
    {
        private readonly ICreateDetection _createDetection;

        public Resolver(ICreateDetection createDetection) => _createDetection = createDetection;

        public IEnumerable<MDetection> Execute(IResolveFieldContext<object> input)
        {
            var detection = input.GetArgument<IEnumerable<MCreateDetection>>("input");
            return _createDetection.Execute(detection);
        }
    }
}
