namespace Data
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EDetection
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public string Class { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
