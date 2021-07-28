namespace Business.Camera.Fetching.Models
{
    using System.Collections.Generic;
    using Business.Pagination.Models;

    public class PCamera
    {
        public List<string>? Ids { get; set; }

        public PPagination Pagination { get; set; } = new PPagination();
    }
}
