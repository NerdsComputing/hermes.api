namespace Data
{
    using System.ComponentModel.DataAnnotations;

    public class ECamera
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public int Latitude { get; set; }

        [Required]
        public int Longitude { get; set; }
    }
}
