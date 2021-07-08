namespace Business.Models
{
    using System;

    public class MDetection
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public object Class { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
