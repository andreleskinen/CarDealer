using CarShop.API.DTO.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL Server Service Registration 
builder.Services.AddDbContext<CarShopContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("CarShopConnection")));

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
        opt.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
    );
});

RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

RegisterEndpoints();

app.UseCors("CorsAllAccessPolicy");

app.Run();

void RegisterEndpoints()
{
    app.AddEndpoint<Car, CarPostDTO, CarPutDTO, CarGetDTO>();
    /*
    app.AddEndpoint<CarCategory, CarCategoryDTO>();
    app.AddEndpoint<CarColor, CarColorDTO>();
    app.AddEndpoint<CarFilter, CarFilterDTO>();
    app.AddEndpoint<Category, CategoryPostDTO, CategoryPutDTO, CategoryGetDTO>();
    app.AddEndpoint<Color, ColorPostDTO, ColorPutDTO, ColorGetDTO>();
    app.AddEndpoint<Filter, FilterPostDTO, FilterPutDTO, FilterGetDTO>();
    app.AddEndpoint<Make, MakePostDTO, MakePutDTO, MakeGetDTO>();
    app.AddEndpoint<Mileage, MileagePostDTO, MileagePutDTO, MileageGetDTO>();
    app.AddEndpoint<Model, ModelPostDTO, ModelPutDTO, ModelGetDTO>();
    app.AddEndpoint<Price, PricePostDTO, PricePutDTO, PriceGetDTO>();
    app.AddEndpoint<Year, YearPostDTO, YearPutDTO, YearGetDTO>();
    */





    /*app.MapGet($"/api/categorieswithdata", async (IDbService db) =>
    {
        try
        {
            return Results.Ok(await ((CarDbService)db).GetCategoriesWithAllRelatedDataAsync());
        }
        catch
        {
        }

        return Results.BadRequest($"Couldn't get the requested products of type {typeof(Product).Name}.");
    });*/
}
void RegisterServices()
{
    ConfigureAutoMapper();
    builder.Services.AddScoped<IDbService, CategoryDbService>();
}
void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Car, CarPostDTO>().ReverseMap();
        cfg.CreateMap<Car, CarPutDTO>().ReverseMap();
        cfg.CreateMap<Car, CarGetDTO>().ReverseMap();
        cfg.CreateMap<CarCategory, CarCategoryDTO>().ReverseMap();
        /*
        cfg.CreateMap<Filter, FilterGetDTO>().ReverseMap();
        cfg.CreateMap<Size, OptionDTO>().ReverseMap();
        cfg.CreateMap<Color, OptionDTO>().ReverseMap();
        */
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}

