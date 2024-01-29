using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.API.DTO;

public class YearPostDTO
{
    public string Name { get; set; } = string.Empty;
}
public class YearPutDTO : YearPostDTO
{
    public int Id { get; set; }
}
public class YearGetDTO : YearPutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
}
