using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication3.ViewModels;

public partial class ActionPrinterProfileViewModel : ViewModelBase
{
    [ObservableProperty]private string _id;
    [ObservableProperty]private string _name;
    [ObservableProperty]private string _description;
    [ObservableProperty]private int _coppies;
    private ObservableCollection<ActionPrinterSettingViewModel> _printerSettings;
    
}