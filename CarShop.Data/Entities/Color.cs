using System;
namespace CarShop.Data.Entities;

public class Color : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CarColor> CarColors { get; set; }
    public List<Car>? Cars { get; set; }
}

