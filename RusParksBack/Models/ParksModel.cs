using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RusParksBack.Models;

public class ParksModel
{
    [Key]
    public int parkid { get; set; }
    
    public string parkname { get; set; }
    
    public string parkcity { get; set; }
    [MaybeNull]
    public string parkmetro { get; set; }
    
    public string smallimage { get; set; }
    
    public string[] mainimages { get; set; }
    
    public string maintext { get; set; }
    [MaybeNull]
    public string enterinfotext { get; set; }
    
    public int[] typeid { get; set; }
}