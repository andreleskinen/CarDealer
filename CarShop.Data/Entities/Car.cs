﻿using System;
namespace CarShop.Data.Entities;

public class Car : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string PictureURL { get; set; } = string.Empty;
    public Make? Make { get; set; }
    public Model? Model { get; set; }

    public List<Category>? Categories { get; set; }
    public List<Color>? Colors { get; set; }
    public List<Filter>? Filters { get; set; }

    public int? Year { get; set; }
    public double? Price { get; set; }
    public int? Mileage { get; set; }

    public OptionType? OptionTypes { get; set; }
    public CarType? CarType { get; set; }
}

