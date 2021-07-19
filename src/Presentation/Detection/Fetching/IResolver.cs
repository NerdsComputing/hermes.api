namespace Presentation.Detection.Fetching
{
    using System.Collections.Generic;
    using Business.Detection.Common.Commands;
    using Business.Detection.Common.Models;
    using global::GraphQL;

    public interface IResolver : ICommand<IResolveFieldContext<object>, IEnumerable<MDetection>>
    {
    }
}
