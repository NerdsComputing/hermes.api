namespace Presentation.Detection.Fetching
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
                new MDetection { Id = 2, Class = "Cardboard", Score = 80, Timestamp = DateTime.UtcNow },
            };
    }
}
