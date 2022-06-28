namespace SynthBoardCollab.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SoundFile 
{
    [Key]
    public int SoundFileID {get; set;}
    
    [Required(ErrorMessage = "is required.")]
    [MinLength(3, ErrorMessage = "must be at least 3 characters.")]
    public string Name {get; set;}
    public string KeyPath {get; set;}
    public int UserID {get; set;}
    public User? Creator {get; set;}
    
}