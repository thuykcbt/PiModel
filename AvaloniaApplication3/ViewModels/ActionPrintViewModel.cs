using System.Text.Json;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication3.ViewModels;

public partial class ActionPrintViewModel :ViewModelBase
{
    [property: JsonIgnore]
    private string _savedState = "";
    [ObservableProperty][NotifyPropertyChangedFor(nameof(HasChanged))] private string _id="";
    [ObservableProperty][NotifyPropertyChangedFor(nameof(HasChanged))] private string _jobname="";

    
    
    [ObservableProperty][NotifyPropertyChangedFor(nameof(HasChanged))] private string _description="";
    [ObservableProperty][NotifyPropertyChangedFor(nameof(HasChanged))] private string _printDrawingRange="";
    [ObservableProperty][NotifyPropertyChangedFor(nameof(HasChanged))] private string _drawingExclusionList="";
    [ObservableProperty][NotifyPropertyChangedFor(nameof(HasChanged))] private bool _drawingExclusionIsWhiteList;
    public string DrawingExclusionListTitle => DrawingExclusionIsWhiteList ? "White List" : "Black List";
    [ObservableProperty][NotifyPropertyChangedFor(nameof(HasChanged))] private bool _printModels;
    [ObservableProperty][NotifyPropertyChangedFor(nameof(HasChanged))] private bool _printDrawings;
    [ObservableProperty] private bool _isNewItem;
    [ObservableProperty][NotifyPropertyChangedFor(nameof(HasChanged))] private string _printerProfileID = "1";

    [JsonIgnore] public bool HasChanged => IsNewItem ||(_savedState != "" && _savedState != JsonSerializer.Serialize(this));
 
    public void SetSavedState()
    {
        _savedState = JsonSerializer.Serialize(this);
        OnPropertyChanged(nameof(HasChanged));
    }
    public void RestoreSavedState()
    {
        var somClass=JsonSerializer.Deserialize<ActionPrintViewModel>(_savedState);
        foreach (var propertyInfo in GetType().GetProperties())
        {
            if (!propertyInfo.CanWrite)
                continue;
            if(propertyInfo.GetCustomAttributes(typeof(JsonIgnoreAttribute), false).GetLength(0)>0)
                continue;
            // Pull the saved value
            var originalValue = propertyInfo.GetValue(somClass);
            
            // Restore it to this class
            propertyInfo.SetValue(this, originalValue);
        }
        
    }
    
}