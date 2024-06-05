using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace denemelog.Models;

public class Coffee
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [DisplayName("Adress")]
    public string Address { get; set; }
    [DisplayName("Recommendations")]
    public string Recommendation { get; set; }
    
    [DisplayName("Ratings")]
    [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
    public int Rating { get; set; }

}