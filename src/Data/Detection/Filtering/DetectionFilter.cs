namespace Data.Detection.Filtering
{
    using System;
    using System.Linq;
    using Business.Detection.Fetching.Models;
    using Microsoft.EntityFrameworkCore;

    public class DetectionFilter : IDetectionFilter
    {
        private PDetection _parameter;

        public IDetectionFilter With(PDetection parameter)
        {
            _parameter = parameter;
            return this;
        }

        public IQueryable<EDetection> Execute(IQueryable<EDetection> input)
        {
            input = MatchId(input);
            input = MatchScore(input);
            input = MatchClass(input);
            input = MatchTimestamp(input);
            return MatchCameraId(input);
        }

        private IQueryable<EDetection> MatchId(IQueryable<EDetection> input) =>
            _parameter.Id != null ? input.Where(detection => detection.Id == _parameter.Id) : input;

        private IQueryable<EDetection> MatchScore(IQueryable<EDetection> input) =>
            _parameter.Score != null ? input.Where(detection => detection.Score == _parameter.Score) : input;

        private IQueryable<EDetection> MatchClass(IQueryable<EDetection> input) =>
            !string.IsNullOrEmpty(_parameter.Class)
                ? input.Where(detection => EF.Functions.Like(detection.Class, $"%{_parameter.Class}%")) : input;

        private IQueryable<EDetection> MatchTimestamp(IQueryable<EDetection> input) =>
            _parameter.Timestamp != DateTime.MinValue
                ? input.Where(detection => detection.Timestamp == _parameter.Timestamp)
                : input;

        private IQueryable<EDetection> MatchCameraId(IQueryable<EDetection> input) =>
            !string.IsNullOrEmpty(_parameter.CameraId)
                ? input.Where(detection => EF.Functions.Like(detection.CameraId, $"%{_parameter.CameraId}%")) : input;
    }
}