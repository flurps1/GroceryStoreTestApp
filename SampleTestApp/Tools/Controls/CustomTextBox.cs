using Avalonia.Controls;
using Avalonia.Input;

namespace SampleTestApp;

public class CustomTextBox : TextBox
{
    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        // Проверяем, нажата ли правая кнопка мыши
        if (e.GetCurrentPoint(this).Properties.IsRightButtonPressed)
        {
            // Ваш кастомный обработчик логики для правой кнопки мыши
            if (DataContext is ProfileViewModel viewModel)
            {
                viewModel.ToggleEditModeCommand.Execute(null);
            }

            // Устанавливаем Handled в true, чтобы отключить стандартное поведение
            e.Handled = true;
        }

        // Вызываем базовую логику для других кнопок
        base.OnPointerPressed(e);
    }

    // Отключаем встроенное контекстное меню
    protected void OnContextRequested(ContextRequestedEventArgs e)
    {
        e.Handled = true; // Полностью блокируем появление контекстного меню
    }
}
