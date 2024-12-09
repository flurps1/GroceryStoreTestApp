using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using FluentAvalonia.UI.Controls;

namespace SampleTestApp;

public class MenuItemTemplateSelector : DataTemplateSelector
{
    private static readonly FuncDataTemplate<MenuItem> ItemTemplate;

    static MenuItemTemplateSelector()
    {
        ItemTemplate = new FuncDataTemplate<MenuItem>((item, _) =>
            new NavigationViewItem
            {
                Content = item.Title,
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