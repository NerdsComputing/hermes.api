using System;

namespace Business.Models
{
    public class MDetection
    {
        public int Id { set; get; }
        public int Score { set; get; }
        public object Class { set; get; }
        public DateTime Timestep { set; get; }

    }
}
