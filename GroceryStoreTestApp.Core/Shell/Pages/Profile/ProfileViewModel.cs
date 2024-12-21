using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GroceryStoreTestApp.Core;

public partial class ProfileViewModel : PageViewModel
{
    [ObservableProperty] private string _firstName;
    [ObservableProperty] private string _lastName;
    [ObservableProperty] private string _middleName;
    [ObservableProperty] private string _fullName;
    [ObservableProperty] private int _age;
    [ObservableProperty] private string _phoneNumber;
    [ObservableProperty] private string _email;
    [ObservableProperty] private float _balance;
    [ObservableProperty] private bool _isEditMode = true;

    public bool IsPhoneValid => Regex.IsMatch(PhoneNumber ?? string.Empty, @"^\+?\d{10,15}$");
    public bool IsEmailValid => Regex.IsMatch(Email ?? string.Empty, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

    public ProfileViewModel()
    {
        PageName = ApplicationPageNames.Profile;

        Balance = 4000.00f;
        Age = 28;
        FirstName = "Иван";
        LastName = "Иванов";
        MiddleName = "Иванович";
        FullName = $"{FirstName} {MiddleName} {LastName}";
        PhoneNumber = "+71234445566";
        Email = "ivan@test.com";
    }

    [RelayCommand]
    private void ToggleEditMode()
    {
        IsEditMode = !IsEditMode;
    }

    partial void OnFirstNameChanged(string value)
    {
        FullName = $"{value} {MiddleName} {LastName}";
    }

    partial void OnMiddleNameChanged(string value)
    {
        FullName = $"{FirstName} {value} {LastName}";
    }

    partial void OnLastNameChanged(string value)
    {
        FullName = $"{FirstName} {MiddleName} {value}";
    }
}