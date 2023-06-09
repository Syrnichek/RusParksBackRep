using Microsoft.EntityFrameworkCore;
using RusParksBack.Models;

namespace RusParksBack;

public class ApplicationContext :DbContext
{
    public DbSet<UsersModel> users { get; set; } = null!;

    public DbSet<ParksModel> parks { get; set; } = null!;

    public DbSet<LandmarksModel> landmarks { get; set; } = null!;

    public DbSet<ReviewsModel> reviews { get; set; } = null!;
    
    public DbSet<NewsModel> news { get; set; } = null!;
    
    //public DbSet<RolesModel> roles { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    { 
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RusParksDb;Username=postgres;Password=1111");
    }
}