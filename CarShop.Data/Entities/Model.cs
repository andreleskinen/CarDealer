using System;
namespace CarShop.Data.Entities;
// 1 to Many relation
public class Model : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}

