namespace Business.Detection.Fetching.Models
{
    using System;
    using Business.Pagination.Models;

    public class PDetection
    {
        public int? Id { get; set; }

        public float? Score { get; set; }

        public string Class { get; set; }

        public MTimestampFilter TimestampFilter { get; set; } = new MTimestampFilter();

        public PPagination Pagination { get; set; } = new PPagination();

        public string CameraId { get; set; }
    }
}
