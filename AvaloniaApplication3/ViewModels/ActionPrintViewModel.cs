using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication3.ViewModels;

public partial class ActionPrintViewModel :ViewModelBase
{
    [ObservableProperty] private string _id;
    [ObservableProperty] private string _jobname;
    [ObservableProperty] private bool _isSelected;
    
    
    [ObservableProperty] private string _description;
    [ObservableProperty] private string _printDrawingRange;
    [ObservableProperty] private string _drawingExclusionList;
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(DrawingExclusionListTitle))] private bool _drawingExclusionIsWhiteList;
    public string DrawingExclusionListTitle => DrawingExclusionIsWhiteList ? "White List" : "Black List";
    [ObservableProperty] private bool _printModels;
    [ObservableProperty] private bool _printDrawings;
    
}