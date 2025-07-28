using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp2.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    string title;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotLoading))]
    bool isLoading;
    
    public bool IsNotLoading => !IsLoading;
}