namespace CarShop.UI.Service;
public class UIService(CategoryHttpClient categoryHttp,CarHttpClient carHttp, IMapper mapper)
{
    List<CategoryGetDTO> Categories { get; set; } = [];
    public List<CarGetDTO> Cars { get; private set; } = [];
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

        linkOption!.IsSelected = true;
    }

    public async Task OnCategoryLinkClick(int id)
    {
        CurrentCatgeoryId = id;
        await GetProductsAsync();
        //Products.ForEach(p => p.Colors!.First().IsSelected = true);

        CategoryLinkGroups[0].LinkOptions.ForEach(l => l.IsSelected = false);
        CategoryLinkGroups[0].LinkOptions.Single(l => l.Id.Equals(CurrentCatgeoryId)).IsSelected = true;
    }

    public async Task GetProductsAsync() => Cars = await carHttp.GetProductAsync(CurrentCatgeoryId);
}