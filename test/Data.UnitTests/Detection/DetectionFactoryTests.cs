namespace Data.UnitTests.Detection
{
    using System;
    using Business.Camera.Common.Models;
    using Business.Detection.Common.Models;
    using Business.Detection.Creating.Models;
    using Data.Detection;
    using NUnit.Framework;
    using Shouldly;

    public class DetectionFactoryTests
    {
        private MDetection _model;
        private EDetection _entity;
        private MCreateDetection _modelCreate;

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
            var outputDetection = DetectionFactory.MakeModel(_entity);

            _model.ShouldBeEquivalentTo(outputDetection);
        }

        [Test]
        public void Factory_ShouldConvert_Input()
        {
            var outputDetection = DetectionFactory.MakeEntity(_modelCreate);

            _entity.ShouldBeEquivalentTo(outputDetection);
        }

        private static EDetection CreateEntity() => new ()
        {
            Id = 0,
            Class = "Class",
            Score = 100,
            Timestamp = new DateTime(2021, 07, 20),
            Camera = new ECamera
            {
                Id = "1",
                Latitude = "1",
                Longitude = "1",
            },
        };

        private static MCreateDetection CreateInput() => new ()
        {
            Class = "Class",
            Score = 100,
            Timestamp = new DateTime(2021, 07, 20),
        };

        private static MDetection CreateModel() => new ()
        {
            Id = 0,
            Class = "Class",
            Score = 100,
            Timestamp = new DateTime(2021, 07, 20),
            Camera = new MCamera
            {
                Id = "1",
                Latitude = "1",
                Longitude = "1",
            },
        };
    }
}
