namespace Presentation.Detection.Creating
{
    using System;
    using System.Collections.Generic;
    using Business.Detection.Creating.Models;
    using global::GraphQL;

    public class Resolver : IResolver
    {
        public IEnumerable<MCreateDetection> Execute(IResolveFieldContext<object> input) =>
            new[]
            {
                new MCreateDetection() { Class = "Pet", Score = 60, Timestamp = DateTime.UtcNow },
            };
    }
}
