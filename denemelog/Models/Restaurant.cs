using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace denemelog.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string Recommendation { get; set; }

        [DisplayName("Ratings")]
        
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }
    }
}