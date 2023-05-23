using System.ComponentModel.DataAnnotations;

namespace RusParksBack.Models;

public class LandmarksModel
{
    [Key]
    public int landmarkid { get; set; }
    
    public string landmarkimage { get; set; }
    
    public int parkid { get; set; }
    
    public string landmarkname { get; set; }
    
    public string landmarktext { get; set; }
}