using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication3.ActionViews;
using AvaloniaApplication3.Data;
using AvaloniaApplication3.ViewModels;

namespace AvaloniaApplication3.Views;

public partial class ActionPageView : UserControl
{
    public ActionPageView()
    {
        InitializeComponent();
    }

    private void ActionTab_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Equals(e.Source, ActionTabControl))  OnTabChanged();
    }

    private void OnTabChanged()
    {
     
        // Get active tab control (Pages insides of each tab)
        var selectedTab = (Control)(ActionTabControl?.SelectedItem as TabItem)?.Content!;

        if(selectedTab == null)
            return;
        // Convert to ActionsPageName

        var actionTabName = selectedTab switch
        {
            Print => ApplicationTabActionPage.Print,
            _ => ApplicationTabActionPage.Unknown,
        };
        // get view model
        var viewModel = selectedTab.DataContext as ActionPageViewModel;
        // type check
        viewModel?.RefreshActionPage(actionTabName);
    }
}