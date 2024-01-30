
namespace CarShop.Data.Context;

public class CarShopContext(DbContextOptions<CarShopContext> builder) : DbContext(builder)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Make> Makes { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Filter> Filters { get; set; }
    public DbSet<CarColor> CarColors { get; set; }
    public DbSet<CarCategory> CarCategories { get; set; }
    public DbSet<CategoryFilter> CategoryFilters { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Composite Keys
        builder.Entity<Car>()
            .HasKey(cb => cb.Id);

        builder.Entity<CarCategory>()
            .HasKey(cc1 => new { cc1.CarId, cc1.CategoryId });

        builder.Entity<CarColor>()
            .HasKey(cc2 => new { cc2.CarId, cc2.ColorId });

        builder.Entity<CategoryFilter>()
            .HasKey(cf => new { cf.CategoryId, cf.FilterId });

        builder.Entity<Category>()
            .HasKey(cm1 => cm1.Id );

        builder.Entity<Color>()
            .HasKey(cm2 => cm2.Id );

        builder.Entity<Filter>()
            .HasKey(f => f.Id);

        builder.Entity<Make>()
            .HasKey(cm3 => cm3.Id );

        builder.Entity<Model>()
            .HasKey(cpy => cpy.Id );


        #endregion

        #region CarColor Many-to-Many Relationship
        builder.Entity<Car>()
            .HasMany(c => c.Colors)
            .WithMany(c => c.Cars)
            .UsingEntity<CarColor>();
        #endregion

        #region CarFilter Many-to-Many Relationship
        builder.Entity<Category>()
            .HasMany(c => c.Filters)
            .WithMany(f => f.Categories)
            .UsingEntity<CategoryFilter>();
        #endregion
    }
}
