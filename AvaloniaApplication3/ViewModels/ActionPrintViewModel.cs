using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication3.ViewModels;

public partial class ActionPrintViewModel :ViewModelBase
{
    [ObservableProperty] private string _id;
    [ObservableProperty] private string _jobname;
    [ObservableProperty] private bool _isSelected;
    
}