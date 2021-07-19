namespace Business.Detection.Common.Models
{
    using System;

    public class MCreateDetection
    {
        public int Score { get; set; }

        public string Class { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
