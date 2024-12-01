using Microsoft.EntityFrameworkCore;
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    public DbSet<User>? Users { get; set; }
    public DbSet<Server>? Servers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=my_db;Username=test412;Password=nopidors");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Server>()
            .HasOne(s => s.User) // Каждый сервер имеет одного пользователя
            .WithMany(u => u.Servers) // Один пользователь может иметь много серверов
            .HasForeignKey(s => s.UserId); // Указываем внешний ключ
    }
    
}