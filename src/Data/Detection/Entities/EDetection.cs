namespace Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EDetection
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public float Score { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public string CameraId { get; set; }

        [Required]
        public virtual ECamera Camera { get; set; }
    }
}
