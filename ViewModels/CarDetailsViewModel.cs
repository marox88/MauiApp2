using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp2.Models;

namespace MauiApp2.ViewModels;

[QueryProperty(nameof(Car), "Car")]
public partial class CarDetailsViewModel : BaseViewModel
{
    [ObservableProperty] private Car car;
}