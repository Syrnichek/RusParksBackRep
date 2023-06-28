using System.ComponentModel.DataAnnotations;

namespace RusParksBack.Models;

public class NewsModel
{
    [Key]
    public int newsid { get; set; }
    
    public string newstitle { get; set; }
    
    public string newsimage { get; set; }

    public DateTime newsdate { get; set; }
    
    public string newstext { get; set; }
}