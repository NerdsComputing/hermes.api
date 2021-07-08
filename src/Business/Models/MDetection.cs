namespace Business.Models
{
    using System;

    public class MDetection
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public string Class { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
