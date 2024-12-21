using Avalonia.Controls;
using Avalonia.Controls.Templates;
using FluentAvalonia.UI.Controls;

namespace GroceryStoreTestApp.Core;

public class MenuItemTemplateSelector : DataTemplateSelector
{
    private static readonly FuncDataTemplate<MenuItem> ItemTemplate;

    static MenuItemTemplateSelector()
    {
        ItemTemplate = new FuncDataTemplate<MenuItem>((item, _) =>
            new NavigationViewItem
            {
                Content = item.Title,
                IconSource = new BitmapIconSource
                {
                    UriSource = item.IconUri
                }
            });
    }

    public static readonly MenuItemTemplateSelector Instance = new();

    protected override IDataTemplate? SelectTemplateCore(object item)
    {
        return item is MenuItem ? ItemTemplate : null;
    }

    protected override IDataTemplate? SelectTemplateCore(object item, Control container)
    {
        return SelectTemplateCore(item);
    }
}