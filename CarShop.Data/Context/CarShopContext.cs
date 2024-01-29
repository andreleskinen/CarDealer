
namespace CarShop.Data.Context;

public class CarShopContext(DbContextOptions<CarShopContext> builder) : DbContext(builder)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Make> Makes { get; set; }
    public DbSet<Year> Years { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Mileage> Mileages { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<CarColor> CarColors { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Composite Keys
        builder.Entity<Car>()
            .HasKey(cb => cb.Id);

        builder.Entity<CarColor>()
            .HasKey(cc => new { cc.CarId, cc.ColorId });

        builder.Entity<CarFilter>()
            .HasKey(cf => new { cf.CarId, cf.FilterId });

        builder.Entity<Category>()
            .HasKey(cm1 => cm1.CategoryId );

        builder.Entity<Color>()
            .HasKey(cm2 => cm2.Id );

        builder.Entity<Make>()
            .HasKey(cm3 => cm3.Id );

        builder.Entity<Mileage>()
            .HasKey(cp => cp.Id );

        builder.Entity<Model>()
            .HasKey(cpy => cpy.Id );

        builder.Entity<Price>()
            .HasKey(cpi => cpi.Id);

        builder.Entity<Year>()
            .HasKey(cp4 => cp4.Id);


        #endregion

        #region CarColor Many-to-Many Relationship
        builder.Entity<Car>()
            .HasMany(c => c.Colors)
            .WithMany(c => c.Cars)
            .UsingEntity<CarColor>();
        #endregion

        #region CarFilter Many-to-Many Relationship
        builder.Entity<Car>()
            .HasMany(c => c.Filters)
            .WithMany(f => f.Cars)
            .UsingEntity<CarFilter>();
        #endregion
    }
}
