using Business.Detection.Common.Models;
using Data;
using Data.Detection;
using FluentAssertions;
using NUnit.Framework;

namespace FactoryDetectionTests
{
    public class ConvertDetection
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DetectionFactoryTest()
        {
            var actualDetection = new MDetection {
                Id = 1,
                Class = "Class",
                Score = 100
            };
            var testDetection = new EDetection {
                Id = 1,
                Class = "Class",
                Score = 100
            };
            var outputDetection = DetectionFactory.MakeModel(testDetection);
            
            actualDetection.Should().BeEquivalentTo(outputDetection);
        }
    }
}