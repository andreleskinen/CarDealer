namespace CarShop.UI.Service;
public class UIService(CategoryHttpClient categoryHttp, IMapper mapper)
{
    List<CategoryGetDTO> Categories { get; set; } = [];
    public List<LinkGroup> CategoryLinkGroups { get; private set; } =
    [
        new LinkGroup
        {
            Name = "Biltyp",
            /*
            LinkOptions = new()
            {
                new LinkOption { Id = 1, Name = "Sedan", IsSelected = true },
                new LinkOption { Id = 2, Name = "Kombi", IsSelected = false },
                new LinkOption { Id = 3, Name = "SUV", IsSelected = false },
                new LinkOption { Id = 4, Name = "Coupé", IsSelected = false }
            }*/
        }
    ];
    public int CurrentCatgeoryId { get; set; } 

    public async Task GetLinkGroups()
    {
        Categories = await categoryHttp.GetCategoriesAsync();
        CategoryLinkGroups[0].LinkOptions = mapper.Map<List<LinkOption>>(Categories);
        var linkOption = CategoryLinkGroups[0].LinkOptions.FirstOrDefault();
    }
}