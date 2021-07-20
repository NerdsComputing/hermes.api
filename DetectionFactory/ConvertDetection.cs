using System;
using Business.Detection.Common.Models;
using Data;
using Data.Detection;
using FluentAssertions;
using NUnit.Framework;

namespace FactoryDetectionTests
{
    public class ConvertDetection
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

            _model.Should().BeEquivalentTo(outputDetection);
        }
        
        private static EDetection CreateEntity() => new EDetection
        {
            Id = 1,
            Class = "Class",
            Score = 100,
            Timestamp = new DateTime(2021, 07, 20)
        };

        private static MDetection CreateModel() => new MDetection
        {
            Id = 1,
            Class = "Class",
            Score = 100,
            Timestamp = new DateTime(2021, 07, 20)
        };
    }
}