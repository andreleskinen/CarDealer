namespace CarShop.API.DTO.DTOs;

public class MakePostDTO
{
    public string Name { get; set; } = string.Empty;
}
public class MakePutDTO : MakePostDTO
{
    public int Id { get; set; }
}
public class MakeGetDTO : MakePutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
}
