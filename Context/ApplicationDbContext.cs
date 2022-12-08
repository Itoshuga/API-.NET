using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext { // Hot Copy de la bdd
    
    // On fait appelle au constructeur de la classe mère
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {

    }

    public DbSet<Hero> Heroes {get; set;}
    public DbSet<Power> Powers {get; set;}
    public DbSet<Organization> Organizations {get; set;}
}