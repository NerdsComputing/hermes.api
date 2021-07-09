namespace Presentation.Detection.Creating
{
    using System;
    using System.Collections.Generic;
    using Business.Detection.Common.Models;
    using global::GraphQL;

    public class Resolver : IResolver
    {
        public IEnumerable<MDetection> Execute(IResolveFieldContext<object> input) =>
            new[]
            {
                new MDetection { Id = 1, Class = "Pet", Score = 60, Timestamp = DateTime.UtcNow },
            };
    }
}
