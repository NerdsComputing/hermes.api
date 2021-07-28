namespace Presentation.Camera.Fetching
{
    using System.Collections.Generic;
    using Business;
    using Business.Camera.Common.Models;
    using global::GraphQL;

    public interface IResolver : ICommand<IResolveFieldContext<object>, IEnumerable<MCamera>>
    {
    }
}
