namespace Business.Detection.Fetching.Models
{
    using System;

    public class MTimestampFilter
    {
        public DateTime LesserThan { get; set; }

        public DateTime GreaterThan { get; set; }
    }
}
