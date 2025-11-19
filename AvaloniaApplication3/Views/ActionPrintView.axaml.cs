using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication3.ViewModels;

namespace AvaloniaApplication3.Views;

public partial class ActionPrintView : UserControl
{
    public ActionPrintView()
    {
        InitializeComponent();
       
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems is { Count: > 0 } && e.AddedItems[0] is ActionPrintViewModel viewModel)
        {
            // Handle new item
            if (viewModel.IsNewItem)
            {
                JobNameTextBox.SelectAll();
                JobNameTextBox.Focus();
            }
        }
    }
}