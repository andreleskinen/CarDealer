using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.API.DTO;

public class MileagePostDTO
{
    public string Name { get; set; } = string.Empty;
}
public class MileagePutDTO : MileagePostDTO
{
    public int Id { get; set; }
}
public class MileageGetDTO : MileagePutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
}
