using System;
namespace CarShop.Data.Entities;

public class Car : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Category> Categories { get; set; }
    public List<CarColor> CarColors { get; set; }
    public List<Color> Colors { get; set; }

    public Make Make { get; set; }
    public Year Year { get; set; }
    public Price Price { get; set; }
    public Mileage Mileage { get; set; }
    public Model Model { get; set; }
    public OptionType OptionTypes { get; set; }
    public List<Filter>? Filters { get; set; }
}

