using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;

namespace SampleTestApp.Core;

public partial class CartItemViewModel : ViewModelBase
{
    [ObservableProperty] private int _index;
    [ObservableProperty] private string _name;
    private bool _isAvailable;

    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (SetProperty(ref _quantity, value))
                OnPropertyChanged(nameof(AvailabilitySymbol));
        }
    }
    public bool IsAvailable
    {
        get => _isAvailable;
        set
        {
            if (SetProperty(ref _isAvailable, value))
                OnPropertyChanged(nameof(AvailabilitySymbol));
        }
    }

    public Symbol AvailabilitySymbol => IsAvailable ? Symbol.Checkmark : Symbol.Cancel;
}