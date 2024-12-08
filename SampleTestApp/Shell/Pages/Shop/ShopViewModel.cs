using Material.Icons;

namespace SampleTestApp;

public class ShopViewModel : PageViewModel
{
    public ShopViewModel()
    {
        PageName = ApplicationPageNames.Shop;
        Icon = MaterialIconKind.Storefront;
    }
}