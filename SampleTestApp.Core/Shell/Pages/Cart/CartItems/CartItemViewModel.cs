using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;

namespace SampleTestApp.Core;

public partial class CartItemViewModel : ViewModelBase
{
    [ObservableProperty] private int _index;
    [ObservableProperty] private string _name;

    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (SetProperty(ref _quantity, value))
            {
                // Уведомляем об изменении связанных свойств
                OnPropertyChanged(nameof(AvailabilitySymbol));
                OnPropertyChanged(nameof(IsAvailable));
            }
        }
    }

    private bool _isAvailable;
    public bool IsAvailable
    {
        get => _isAvailable;
        set
        {
            if (SetProperty(ref _isAvailable, value))
            {
                // Уведомляем об изменении связанных свойств
                OnPropertyChanged(nameof(AvailabilitySymbol));
            }
        }
    }
    


    public Symbol AvailabilitySymbol => IsAvailable ? Symbol.Checkmark : Symbol.Cancel;

}