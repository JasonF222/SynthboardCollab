namespace SynthBoardCollab.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SoundFile 
{
    [Key]
    public int SoundFileID {get; set;}
    
    [Required(ErrorMessage = "Recording Corrupted. Please record again.")]
    public string Name {get; set;}
    [Required]
    public string KeyPath {get; set;}
    public int? UserID {get; set;}
    public string BoardType {get; set;}
    public User? Creator {get; set;}
    
}