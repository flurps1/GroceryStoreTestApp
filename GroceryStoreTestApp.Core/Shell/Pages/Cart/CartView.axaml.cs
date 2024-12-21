using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace GroceryStoreTestApp.Core;

public partial class CartView : UserControl
{
    public CartView()
    {
        InitializeComponent();
    }

    private void OnTextBoxKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key is not (>= Key.D0 and <= Key.D9 or >= Key.NumPad0 and <= Key.NumPad9 or Key.Back or Key.Delete
            or Key.Tab or Key.Left or Key.Right))
        {
            e.Handled = true;
        }
    }
}