using System.ComponentModel.DataAnnotations;

namespace RusParksBack.Models;

public class ReviewsModel
{
    [Key]
    public int reviewid { get; set; }
    
    public int parkid { get; set; }
    
    public int userid { get; set; }
    
    public int reviewscore { get; set; }
    
    public string reviewtext { get; set; }
}