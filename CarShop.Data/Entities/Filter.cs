using System;
namespace CarShop.Data.Entities;

public class Filter : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TypeName { get; set; }
    public OptionType OptionType { get; set; }
    public List<Car> Cars { get; set; }

}

