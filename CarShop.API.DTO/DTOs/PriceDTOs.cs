using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.API.DTO;

public class PricePostDTO
{
    public string Name { get; set; } = string.Empty;
}
public class PricePutDTO : PricePostDTO
{
    public int Id { get; set; }
}
public class PriceGetDTO : PricePutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
}
