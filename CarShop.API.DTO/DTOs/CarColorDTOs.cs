namespace CarShop.API.DTO.DTOs;

public class CarColorPostDTO
{
    public string Name { get; set; } = string.Empty;
}
public class CarColorPutDTO : CarColorPostDTO
{
    public int Id { get; set; }
}
public class CarColorGetDTO : CarColorPutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
}
