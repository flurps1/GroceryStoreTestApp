using Avalonia.Controls;
using Avalonia.Input;

namespace SampleTestApp;

public class CustomTextBox : TextBox
{
    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsRightButtonPressed)
        {
            if (DataContext is ProfileViewModel viewModel)
            {
                viewModel.ToggleEditModeCommand.Execute(null);
            }

            IsEnabled = !IsEnabled;
        }

        base.OnPointerPressed(e);
    }

    protected void OnContextRequested(ContextRequestedEventArgs e)
    {
        e.Handled = true;
    }
}
