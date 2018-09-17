using System.Collections.Generic;

namespace BookService.Lib.Models
{
    public class Reader : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
