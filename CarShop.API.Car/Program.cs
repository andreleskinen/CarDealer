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
    app.AddEndpoint<CarColor, CarColorDTO>();
    app.AddEndpoint<CategoryFilter, CategoryFilterDTO>();
    app.AddEndpoint<Category, CategoryPostDTO, CategoryPutDTO, CategoryGetDTO>();
    app.AddEndpoint<Color, ColorPostDTO, ColorPutDTO, ColorGetDTO>();
    app.AddEndpoint<Make, MakePostDTO, MakePutDTO, MakeGetDTO>();
    app.AddEndpoint<Model, ModelPostDTO, ModelPutDTO, ModelGetDTO>();
    app.AddEndpoint<CarCategory, CarCategoryDTO>();
    //app.AddEndpoint<Filter, FilterPostDTO, FilterPutDTO, FilterGetDTO>();



    app.MapGet($"/api/carsbycategory/{{categoryId}}", async (IDbService db, int categoryId) =>
    {
        try
        {
            var result = await ((CarDbService)db).GetCarsByCategoryAsync(categoryId);
            return Results.Ok(result);
        }
        catch
        {
        }

        return Results.BadRequest($"Couldn't get the requested cars of type {typeof(Car).Name}.");
    });
}
void RegisterServices()
{
    ConfigureAutoMapper();
    builder.Services.AddScoped<IDbService, CarDbService>();
}

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Car, CarPostDTO>().ReverseMap();
        cfg.CreateMap<Car, CarPutDTO>().ReverseMap();
        cfg.CreateMap<Car, CarGetDTO>().ReverseMap();
        cfg.CreateMap<Car, CarSmallGetDTO>().ReverseMap();
        cfg.CreateMap<Color, ColorPostDTO>().ReverseMap();
        cfg.CreateMap<Color, ColorPutDTO>().ReverseMap();
        cfg.CreateMap<Color, ColorGetDTO>().ReverseMap();
        cfg.CreateMap<Make, MakePostDTO>().ReverseMap();
        cfg.CreateMap<Make, MakePutDTO>().ReverseMap();
        cfg.CreateMap<Make, MakeGetDTO>().ReverseMap();
        cfg.CreateMap<Model, ModelPostDTO>().ReverseMap();
        cfg.CreateMap<Model, ModelPutDTO>().ReverseMap();
        cfg.CreateMap<Model, ModelGetDTO>().ReverseMap();
        cfg.CreateMap<CarCategory, CarCategoryDTO>().ReverseMap();


        /*
        cfg.CreateMap<Filter, FilterPostDTO>().ReverseMap();
        cfg.CreateMap<Filter, FilterPutDTO>().ReverseMap();
        cfg.CreateMap<Filter, FilterGetDTO>().ReverseMap();
        cfg.CreateMap<Filter, FilterGetDTO>().ReverseMap();
        cfg.CreateMap<Size, OptionDTO>().ReverseMap();
        cfg.CreateMap<Color, OptionDTO>().ReverseMap();
        */
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}




