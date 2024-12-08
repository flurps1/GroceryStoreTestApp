using Material.Icons;

namespace SampleTestApp;

public class MenuItem
{
    public MenuItem(ApplicationPageNames pageName, string title, MaterialIconKind icon)
    {
        PageName = pageName;
        Title = title;
        Icon = icon;
    }

    /// <summary>
    /// Имя страницы для навигации.
    /// </summary>
    public ApplicationPageNames PageName { get; }

    /// <summary>
    /// Отображаемый заголовок пункта меню.
    /// </summary>
    public string Title { get; }
    
    /// <summary>
    /// Иконка пункта меню (путь к ресурсам или имя иконки).
    /// </summary>
    public MaterialIconKind Icon { get; }

    //public bool IsMinimal { get; set; }
}