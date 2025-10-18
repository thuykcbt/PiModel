using AvaloniaApplication3.Data;
using AvaloniaApplication3.ViewModels;

namespace AvaloniaApplication3.ViewModels;

public partial class HomePageViewModel():PageViewModel( ApplicationPageNames.Home)
{
    public string Test { get; set; } = "Home";
    
}