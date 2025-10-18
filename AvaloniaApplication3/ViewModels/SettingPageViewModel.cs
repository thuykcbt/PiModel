using System.Collections.Generic;
using System.Collections.ObjectModel;
using AvaloniaApplication3.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication3.ViewModels;

public partial class SettingPageViewModel : PageViewModel
{
    [ObservableProperty]
    private ObservableCollection<string> _locationsPaths;
    public SettingPageViewModel() : base(ApplicationPageNames.Setting)
    {
        PageName = ApplicationPageNames.Setting;
        // Remove 
        LocationsPaths = new ObservableCollection<string>
        {
            @"C:\Users\Admin\Downloads",
            @"C:\Users\Admin\Documents",
            @"C:\Users\Admin\Links",
        };


    }
}