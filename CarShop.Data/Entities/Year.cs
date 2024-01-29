using System;
namespace CarShop.Data.Entities;
// 1 to Many relation
public class Year : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}

