using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SynthBoardCollab.Models;

public class User
{
    [Key]
    public int UserID {get; set;}

    [Required(ErrorMessage = "is required.")]
    [MinLength(3, ErrorMessage = "must be at least 3 characters")]
    [Display(Name = "User Name")]
    public string UserName {get; set;}
    
    [Required(ErrorMessage = "is required.")]
    [EmailAddress(ErrorMessage = "must be a valid email address.")]
    public string Email {get; set;}

    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    public string Password {get; set;}

    [NotMapped]
    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "must match password")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public List<Favorite> FavoriteBoards {get; set;} = new List<Favorite>();
}