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
            input = MatchScoreLesserThan(input);
            input = MatchScoreGreaterThan(input);
            input = MatchClass(input);
            input = MatchTimestampLesserThan(input);
            input = MatchTimestampGreaterThan(input);
            return MatchCameraId(input);
        }

        private IQueryable<EDetection> MatchId(IQueryable<EDetection> input) =>
            _parameter.Id != null ? input.Where(detection => detection.Id == _parameter.Id) : input;

        private IQueryable<EDetection> MatchScoreLesserThan(IQueryable<EDetection> input) =>
            _parameter.Score.LesserEqualThan != null
                ? input.Where(detection => detection.Score <= _parameter.Score.LesserEqualThan)
                : input;

        private IQueryable<EDetection> MatchScoreGreaterThan(IQueryable<EDetection> input) =>
            _parameter.Score.GreaterEqualThan != null
                ? input.Where(detection => detection.Score >= _parameter.Score.GreaterEqualThan)
                : input;

        private IQueryable<EDetection> MatchClass(IQueryable<EDetection> input) =>
            string.IsNullOrEmpty(_parameter.Class)
                ? input
                : input.Where(detection => EF.Functions.Like(detection.Class, $"%{_parameter.Class}%"));

        private IQueryable<EDetection> MatchTimestampLesserThan(IQueryable<EDetection> input) =>
            _parameter.Timestamp.LesserEqualThan != null
                ? input.Where(detection => detection.Timestamp <= _parameter.Timestamp.LesserEqualThan)
                : input;

        private IQueryable<EDetection> MatchTimestampGreaterThan(IQueryable<EDetection> input) =>
            _parameter.Timestamp.GreaterEqualThan != null
                ? input.Where(detection => detection.Timestamp >= _parameter.Timestamp.GreaterEqualThan)
                : input;

        private IQueryable<EDetection> MatchCameraId(IQueryable<EDetection> input) =>
            string.IsNullOrEmpty(_parameter.CameraId)
                ? input
                : input.Where(detection => EF.Functions.Like(detection.CameraId, $"%{_parameter.CameraId}%"));
    }
}
