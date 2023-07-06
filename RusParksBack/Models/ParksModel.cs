using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    
    [MaybeNull]
    public string smallimage { get; set; }

    [MaybeNull]
    public string[] imagespath { get; set; }
    public string maintext { get; set; }
    
    [MaybeNull]
    public string enterinfotext { get; set; }
    
    public int[] typeid { get; set; }
}