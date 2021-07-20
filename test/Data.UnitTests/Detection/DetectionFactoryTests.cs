namespace Data.UnitTests.Detection
{
    using System;
    using Business.Detection.Common.Models;
    using Data.Detection;
    using NUnit.Framework;
    using Shouldly;

    public class DetectionFactoryTests
    {
        private MDetection _model;
        private EDetection _entity;

        [SetUp]
        public void Setup()
        {
            _model = CreateModel();
            _entity = CreateEntity();
        }

        [Test]
        public void Factory_ShouldConvert_Entity()
        {
            var outputDetection = DetectionFactory.MakeModel(_entity);

            _model.ShouldBeEquivalentTo(outputDetection);
        }

        private static EDetection CreateEntity() => new ()
        {
            Id = 1,
            Class = "Class",
            Score = 100,
            Timestamp = new DateTime(2021, 07, 20),
        };

        private static MDetection CreateModel() => new ()
        {
            Id = 1,
            Class = "Class",
            Score = 100,
            Timestamp = new DateTime(2021, 07, 20),
        };
    }
}
