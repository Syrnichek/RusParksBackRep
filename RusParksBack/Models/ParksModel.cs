namespace RusParksBack.Models;

public class ParksModel
{
    public int parkid { get; set; }
    
    public string parkname { get; set; }
    
    public string parkcity { get; set; }
    
    public string parkmetro { get; set; }

    public string smallimage { get; set; }
    
    public string[] mainimages { get; set; }
    
    public string maintext { get; set; }
    
    public string enterinfotext { get; set; }
    
    public int[] typeid { get; set; }
}