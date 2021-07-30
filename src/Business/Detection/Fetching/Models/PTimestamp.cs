namespace Business.Detection.Fetching.Models
{
    using System;

    public class PTimestamp
    {
        public DateTime? LesserEqualThan { get; set; }

        public DateTime? GreaterEqualThan { get; set; }
    }
}
