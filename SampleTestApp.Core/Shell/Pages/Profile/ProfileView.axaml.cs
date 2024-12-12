using Avalonia.Controls;
using Avalonia.Input;

namespace SampleTestApp.Core;

public partial class ProfileView : UserControl
{
    public ProfileView()
    {
        InitializeComponent();
    }
    
    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        // Проверяем, нажата ли правая кнопка мыши
        if (e.GetCurrentPoint(this).Properties.IsRightButtonPressed)
        {
            // Вызываем команду из ViewModel
            if (DataContext is ProfileViewModel viewModel)
            {
                viewModel.ToggleEditModeCommand.Execute(null);
            }

            // Прерываем дальнейшую обработку события (чтобы контекстное меню не открывалось)
            e.Handled = true;
        }
    }
    
}