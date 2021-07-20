namespace Presentation.Detection.Creating
{
    using System.Collections.Generic;
    using Business.Detection.Creating.Models;
    using Business.Detection.Fetching.Commands;
    using global::GraphQL;

    public interface IResolver : ICommand<IResolveFieldContext<object>, IEnumerable<MCreateDetection>>
    {
    }
}
