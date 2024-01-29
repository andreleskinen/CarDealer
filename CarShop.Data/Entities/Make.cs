using System;
namespace CarShop.Data.Entities;
// 1 to Many relation
public class Make : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}

