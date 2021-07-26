namespace Data
{
    using System.ComponentModel.DataAnnotations;

    public class ECamera
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }
    }
}
