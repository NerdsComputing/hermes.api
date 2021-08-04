namespace Data
{
    using System.ComponentModel.DataAnnotations;

    public class ECamera
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}
