namespace CarShop.API.DTO;

public class CarPostDTO
{
    public string Name { get; set; } = string.Empty;
}
public class CarPutDTO : CarPostDTO
{
    public int Id { get; set; }
}
public class CarGetDTO : CarPutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
}

