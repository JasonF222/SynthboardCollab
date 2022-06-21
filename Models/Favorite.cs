using System.ComponentModel.DataAnnotations;
namespace SynthBoardCollab.Models;

public class Favorite
{
    [Key]
    public int FavoriteID {get; set;}

    public int UserID {get; set;}
    public int BoardID {get; set;}
    public User? User {get; set;}
    public Board? Board {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;

}