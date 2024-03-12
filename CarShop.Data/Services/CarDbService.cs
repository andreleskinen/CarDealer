using CarShop.API.DTO;
using System.Drawing;

namespace CarShop.Data.Services;

public class CarDbService(CarShopContext db, IMapper mapper) : DbService(db, mapper)
{
    public async Task<List<CarGetDTO>> GetCarsByCategoryAsync(int categoryId)
    {
        //IncludeNavigationsFor<Make>();
        //IncludeNavigationsFor<Model>();
        var productIds = GetAsync<CarCategory>(cc => cc.CategoryId.Equals(categoryId))
            .Select(cc => cc.CarId);
        var products = await GetAsync<Car>(c => productIds.Contains(c.Id)).ToListAsync();
        return MapList<Car, CarGetDTO>(products);
    }
    public List<TDto> MapList<TEntity, TDto>(List<TEntity> entities)
    where TEntity : class
    where TDto : class
    {
        return mapper.Map<List<TDto>>(entities);
    }




    /*public async Task<List<CarGetDTO>> GetCategoriesWithAllRelatedDataAsync() // CategoryGetDTO
    {
        //IncludeNavigationsFor<Filter>();
        //IncludeNavigationsFor<Car>();
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
    }*/
}
