namespace SynthBoardCollab.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class SoundFile 
{
    [Key]
    public int SoundFileID {get; set;}
    
    [Required(ErrorMessage = "is required.")]
    [MinLength(3, ErrorMessage = "must be at least 3 characters.")]
    public string Name {get; set;}

    public Board? Board {get; set;}
    public string? BaseSound {get; set;}
    
}