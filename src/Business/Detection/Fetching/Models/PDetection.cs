namespace Business.Detection.Fetching.Models
{
    using System;
    using Business.Pagination;

    public class PDetection
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public string Class { get; set; }

        public DateTime Timestamp { get; set; }

        public PPagination Pagination { get; set; } = new PPagination();

        public string CameraId { get; set; }
    }
}
