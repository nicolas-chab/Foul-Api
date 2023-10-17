using Foul_Api;
using Microsoft.EntityFrameworkCore;

public class Datacontext : DbContext
{


    public Datacontext(DbContextOptions<Datacontext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=SQL5107.site4now.net;Initial Catalog=db_a5e599_proyecto;User Id=db_a5e599_proyecto_admin;Password=Roma2023");
    }
    public DbSet<user> users => Set<user>();

    //public DbSet<team> Team { get; set; }
    public DbSet<Referee> referees => Set<Referee>();




}

