namespace Business.Detection.Common.Models
{
    using System;
    using Business.Camera.Common.Models;

    public class MDetection
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public string Class { get; set; }

        public DateTime Timestamp { get; set; }

        public MCamera Camera { get; set; }
    }
}
