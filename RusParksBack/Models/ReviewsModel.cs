namespace RusParksBack.Models;

public class ReviewsModel
{
    public int revieiwid { get; set; }
    
    public int parkid { get; set; }
    
    public int userid { get; set; }
    
    public int reviewscore { get; set; }
    
    public string reviewtext { get; set; }
}