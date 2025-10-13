using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication3.ViewModels;


namespace AvaloniaApplication3.Views;

public partial class SettingPageView : UserControl
{
    public SettingPageView()
    {
        InitializeComponent();
        DataContext = new SettingPageViewModel();
     
    }
}