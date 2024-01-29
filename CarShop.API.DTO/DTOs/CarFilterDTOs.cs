namespace CarShop.API.DTO.DTOs;

public class CarFilterPostDTO
{
    public string Name { get; set; } = string.Empty;
}
public class CarFilterPutDTO : CarFilterPostDTO
{
    public int Id { get; set; }
}
public class CarFilterGetDTO : CarFilterPutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
}
