using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;

namespace SampleTestApp;

public partial class CartItemViewModel : ViewModelBase
{
    [ObservableProperty] private int _index;
    [ObservableProperty] private string _name;
    [ObservableProperty] private int _quantity;
    [ObservableProperty] private bool _isAvailable;

    public Symbol AvailabilitySymbol => IsAvailable ? Symbol.Checkmark : Symbol.Cancel;

}