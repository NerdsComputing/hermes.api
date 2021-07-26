namespace Data.UnitTests.Camera
{
    using Business.Camera.Common.Models;
    using Business.Camera.Register.Models;
    using Data.Camera;
    using NUnit.Framework;
    using Shouldly;

    public class CameraFactoryTest
    {
        private MCamera _model;
        private ECamera _entity;
        private MRegisterCamera _modelCreate;

        [SetUp]
        public void Setup()
        {
            _model = CreateModel();
            _modelCreate = CreateInput();
            _entity = CreateEntity();
        }

        [Test]
        public void Factory_ShouldConvert_Entity()
        {
            var outputDetection = CameraFactory.MakeModel(_entity);

            _model.ShouldBeEquivalentTo(outputDetection);
        }

        [Test]
        public void Factory_ShouldConvert_Input()
        {
            var outputDetection = CameraFactory.MakeEntity(_modelCreate);

            _entity.ShouldBeEquivalentTo(outputDetection);
        }

        private static ECamera CreateEntity() => new ()
        {
            Id = "0",
            Latitude = "45.791795",
            Longitude = "24.129404",
        };

        private static MRegisterCamera CreateInput() => new ()
        {
            Id = "0",
            Latitude = "45.791795",
            Longitude = "24.129404",
        };

        private static MCamera CreateModel() => new ()
        {
            Id = "0",
            Latitude = "45.791795",
            Longitude = "24.129404",
        };
    }
}
