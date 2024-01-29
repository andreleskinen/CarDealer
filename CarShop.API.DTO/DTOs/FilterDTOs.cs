namespace CarShop.API.DTO.DTOs;

public class FilterPostDTO
{
    public string Name { get; set; } = string.Empty;
}
public class FilterPutDTO : FilterPostDTO
{
    public int Id { get; set; }
}
public class FilterGetDTO : FilterPutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
}
