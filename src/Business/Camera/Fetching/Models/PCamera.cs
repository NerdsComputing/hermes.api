namespace Business.Camera.Fetching.Models
{
    using System.Collections.Generic;
    using Business.Pagination.Models;

    public class PCamera
    {
        public List<string>? Ids { get; set; }

        public PLatitude Latitude { get; set; } = new PLatitude();

        public PLongitude Longitude { get; set; } = new PLongitude();

        public PPagination Pagination { get; set; } = new PPagination();
    }
}
