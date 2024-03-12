using System;
namespace CarShop.Data.Entities;
public class Model : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public List<Car>? Cars { get; set; }


}

