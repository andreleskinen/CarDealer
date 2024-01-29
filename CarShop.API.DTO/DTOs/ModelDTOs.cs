using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.API.DTO;

public class ModelPostDTO
{
    public string Name { get; set; } = string.Empty;
}
public class ModelPutDTO : ModelPostDTO
{
    public int Id { get; set; }
}
public class ModelGetDTO : ModelPutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
}
