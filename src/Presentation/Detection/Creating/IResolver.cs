namespace Presentation.Detection.Creating
{
    using System.Collections.Generic;
    using Business.Detection.Common.Commands;
    using Business.Detection.Common.Models;
    using Business.Detection.Creating.Models;
    using Business.Detection.Fetching.Commands;
    using global::GraphQL;

    public interface IResolver : ICommand<IResolveFieldContext<object>, IEnumerable<MCreateDetection>>
    {
    }
}
