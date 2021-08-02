namespace Business.Detection.Fetching.Models
{
    using System;
    using System.Collections.Generic;
    using Business.Pagination.Models;

    public class PDetection
    {
        public int? Id { get; set; }

        public PScore? Score { get; set; } = new PScore();

        public string Class { get; set; }

        public PTimestamp Timestamp { get; set; } = new PTimestamp();

        public PPagination Pagination { get; set; } = new PPagination();

        public List<string>? CameraIds { get; set; }
    }
}
