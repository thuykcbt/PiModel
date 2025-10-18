using AvaloniaApplication3.Data;
using AvaloniaApplication3.ViewModels;

namespace AvaloniaApplication3.ViewModels;

public partial class MacrosPageViewModel():PageViewModel( ApplicationPageNames.Marcos)
{
    public string Test { get; set; } = "Home";
}