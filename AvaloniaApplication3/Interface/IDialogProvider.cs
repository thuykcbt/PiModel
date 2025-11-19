using AvaloniaApplication3.ViewModels;

namespace AvaloniaApplication3.Interface;

public interface IDialogProvider
{
    DialogViewModel Dialog { get; set; }
}