using CarShop.API.DTO.DTOs;

namespace CarShop.API.DTO;

public class CarPostDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PictureURL { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Year { get; set; }
    public int Mileage { get; set; }

}
public class CarPutDTO : CarPostDTO
{
    public int Id { get; set; }
}
public class CarGetDTO : CarPutDTO
{
    public int ModelId { get; set; }
    public int MakeId { get; set; }

    public MakeGetDTO? Make { get; set; }
    public ModelGetDTO? Model { get; set; }
    //public List<FilterGetDTO>? Filters { get; set; }
}
public class CarSmallGetDTO : CarPutDTO
{
}
