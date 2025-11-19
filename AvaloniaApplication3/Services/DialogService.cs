using System.Threading.Tasks;
using AvaloniaApplication3.Interface;
using AvaloniaApplication3.ViewModels;

namespace AvaloniaApplication3.Services;

public class DialogService
{
    public async Task ShowDialog<THost,TDialogViewModel>(THost host,TDialogViewModel dialogViewModel)
        where TDialogViewModel: DialogViewModel
        where THost : IDialogProvider
    {
        // Set host dialog to provide one
        host.Dialog = dialogViewModel;
        dialogViewModel.Show();
        // Wait for dialog close
        await dialogViewModel.WaitAsnyc();

    }
    
}