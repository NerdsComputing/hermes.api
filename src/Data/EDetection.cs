namespace Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EDetection
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public string CameraId { get; set; }
    }
}
