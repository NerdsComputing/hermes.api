namespace Business.Detection.Fetching.Models
{
    using System;

    public class PTimestampFilter
    {
        public DateTime? LesserEqualThan { get; set; }

        public DateTime? GreaterEqualThan { get; set; }
    }
}
