using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RusParksBack.Models;

public class ReviewsModel
{
    [Key]
    public int reviewid { get; set; }
    
    public int parkid { get; set; }
    
    public int userid { get; set; }
    
    public int reviewscore { get; set; }
    [MaybeNull]
    public string reviewtext { get; set; }
    
    public string userlogin { get; set; }
}