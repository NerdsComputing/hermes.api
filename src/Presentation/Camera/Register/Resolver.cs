namespace Presentation.Camera.Register
{
    using System.Collections.Generic;
    using Business.Camera.Common.Models;
    using Business.Camera.Register.Commands;
    using Business.Camera.Register.Models;
    using global::GraphQL;

    public class Resolver : IResolver
    {
        private readonly IRegisterCamera _registerCamera;

        public Resolver(IRegisterCamera registerCamera) => _registerCamera = registerCamera;

        public IEnumerable<MCamera> Execute(IResolveFieldContext<object> input)
        {
            IEnumerable<MRegisterCamera> camera = input.GetArgument<IEnumerable<MRegisterCamera>>("input");

            return _registerCamera.Execute(camera);
        }
    }
}
