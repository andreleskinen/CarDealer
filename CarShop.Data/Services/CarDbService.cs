


using CarShop.API.DTO;

namespace CarShop.Data.Services;

public class CarDbService(CarShopContext db, IMapper mapper) : DbService(db, mapper)
{
    public override async Task<List<TDto>> GetAsync<TEntity, TDto>()
    {
        //IncludeNavigationsFor<Filter>();
        //IncludeNavigationsFor<Product>();
        return await base.GetAsync<TEntity, TDto>();
    }

    public async Task<List<CarGetDTO>> GetCategoriesWithAllRelatedDataAsync() // CategoryGetDTO
    {
        IncludeNavigationsFor<Filter>();
        IncludeNavigationsFor<Product>();  //vi behöver skapa product entitet
        var categories = await base.GetAsync<Category, CarGetDTO>(); // CategoryGetDTO

        foreach (var category in categories)
        {
            if (category is null || category.Filters is null) continue;

            foreach (var filter in category.Filters)
            {
                filter.Options = [];

                var dbSetProperty = db.GetType().GetProperties()
                    .FirstOrDefault(p => p.Name.Equals(filter.Name, StringComparison.OrdinalIgnoreCase) &&
                        p.PropertyType.IsGenericType &&
                        p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

                if (dbSetProperty is null) continue;

                // Retrieve the DbSet and cast it to IQueryable<object>
                var dbSet = (IQueryable<object>?)dbSetProperty.GetValue(db);

                if (dbSet is null) continue;

                var data = await dbSet.ToListAsync();

                filter.Options = _mapper.Map<List<OptionDTO>>(data);
            }
        }

        return categories;
    }
}
