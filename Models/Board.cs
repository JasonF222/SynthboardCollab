namespace SynthBoardCollab.Models;
using System.ComponentModel.DataAnnotations;

public class Board
{
    [Key]
    public int BoardID {get; set;}

    [Required(ErrorMessage = "is required.")]
    public string Name {get; set;}
    public string Variant {get; set;}
    public string? CustomSound {get; set;}
    // if the customSound is null, we will use the base oscillator, however if we have a custom sound we will refer to the table 
    // we will use the variant key to determine the frequencies to play the custom sound at
    public List<SoundFile> CustomSounds {get; set;} = new List<SoundFile>();
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
}