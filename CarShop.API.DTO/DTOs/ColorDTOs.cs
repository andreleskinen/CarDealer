namespace CarShop.API.DTO.DTOs;

public class ColorPostDTO
{
    public string Name { get; set; } = string.Empty;
}
public class ColorPutDTO : ColorPostDTO
{
    public int Id { get; set; }
}
public class ColorGetDTO : ColorPutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
}
