namespace SynthBoardCollab.Models;
using Microsoft.EntityFrameworkCore;


public class SynthContext : DbContext
{
    public SynthContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users {get; set;} = null!;
    public DbSet<SoundFile> Sounds {get; set;} = null!;
}