using CarShop.API.DTO;
using System.Drawing;

namespace CarShop.Data.Services;

public class CategoryDbService(CarShopContext db, IMapper mapper) : DbService(db, mapper)
{
    public override async Task<List<TDto>> GetAsync<TEntity, TDto>()
    {
        //IncludeNavigationsFor<Filter>();
        //IncludeNavigationsFor<Product>();
        return await base.GetAsync<TEntity, TDto>();
    }

    public Task<object?> GetCategoriesByCategoryAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CarGetDTO>> GetProductsByCategoryAsync(int categoryId)
    {
        IncludeNavigationsFor<Color>(); //HÄR VET JAG INTE VAD SOM SKA STÅ SOM MOTSVARAR HANS COLOR.
        IncludeNavigationsFor<Size>(); //HÄR VET JAG INTE VAD SOM SKA STÅ SOM MOTSVARAR HANS SIZE.
        var carIds = GetAsync<CarCategory>(cc => cc.CategoryId.Equals(categoryId))
            .Select(cc => cc.CarId);
        var cars = await GetAsync<Car>(c => carIds.Contains(c.Id)).ToListAsync();
        return MapList<Car, CarGetDTO>(cars);
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
