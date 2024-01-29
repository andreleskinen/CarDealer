namespace CarShop.API.DTO;

public class CarCategoryPostDTO
{
    public string Name { get; set; } = string.Empty;
}
public class CarCategoryPutDTO : CarCategoryPostDTO
{
    public int Id { get; set; }
}
public class CarCategoryGetDTO : CarCategoryPutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
}
