namespace SynthBoardCollab.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class LogUser
{
    [Required(ErrorMessage = "is required.")]
    [EmailAddress(ErrorMessage = "must be a valid email address")]
    [Display(Name = "Email")]
    public string LogEmail {get; set;}
    
    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string LogPass {get; set;}

}