﻿namespace SampleTestApp.Core;

public class MenuItem
{
    public MenuItem(ApplicationPageNames pageName, string title)
    {
        PageName = pageName;
        Title = title;
    }

    public ApplicationPageNames PageName { get; }
    public string Title { get; }
}