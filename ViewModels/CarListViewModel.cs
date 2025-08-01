using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp2.Models;
using MauiApp2.Services;
using CommunityToolkit.Mvvm.Input;
using MauiApp2.Views;

namespace MauiApp2.ViewModels;

public partial class CarListViewModel : BaseViewModel
{
   private readonly CarService carService;

   public ObservableCollection<Car> Cars { get; private set; } = new();
   
   public CarListViewModel(CarService carService)
   {
      Title = "Car List";
      this.carService = carService;
   }

   [ObservableProperty] private bool isRefreshing;

   [RelayCommand]
   async Task GetCarList()
   {
      if (IsLoading) return;

      try
      {
         IsLoading = true;
         if (Cars.Any()) Cars.Clear();

         var cars = carService.GetCars();
         foreach (var car in cars)
         {
            Cars.Add(car);
         }
      }
      catch (Exception ex)
      {
         Debug.WriteLine($"Unable to get cars: {ex.Message}");
         await Shell.Current.DisplayAlert("Error", $"Unable to get cars: {ex.Message}", "OK");
         throw;
      }
      finally
      {
         IsLoading = false;
         IsRefreshing = false;
      }
   }

   [RelayCommand]
   async Task GetCarDetails(Car car)
   {
      if (car == null) return;

      await Shell.Current.GoToAsync(nameof(CarDetailsPage), true, new Dictionary<string, object>
      {
         { nameof(Car), car }
      });
   }
}