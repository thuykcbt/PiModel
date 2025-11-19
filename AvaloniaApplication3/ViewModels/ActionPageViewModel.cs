    using System;
     using System.Collections.ObjectModel;
     using AvaloniaApplication3.Data;
     using AvaloniaApplication3.ViewModels;
     using CommunityToolkit.Mvvm.ComponentModel;
     using CommunityToolkit.Mvvm.Input;
    using System.Linq;
    using System.Threading.Tasks;
    using AvaloniaApplication3.Services;

    namespace AvaloniaApplication3.ViewModels;
     
     public partial class ActionPageViewModel : PageViewModel
     {
         private MainViewModel mainViewModel;
         private DialogService dialogService;
        private ActionPrinterProfileViewModel _defaultPrinterProfile = new ActionPrinterProfileViewModel
             { Name = "(Default)", Description = "Use all default settings", Coppies = 1 ,Id = "0"};
         [ObservableProperty]
      
         private ObservableCollection<ActionPrintViewModel> _printList=[];
       
       public bool PrintListHasItems => PrintList.Any();

         [ObservableProperty] private ObservableCollection<ActionPrinterProfileViewModel> _printerProfile = [];

       
       [ObservableProperty]
       [NotifyPropertyChangedFor(nameof(SelectedPrintListItem))]
       private string _selectedPrintListItemId="";
       
       public ActionPrintViewModel?  SelectedPrintListItem => PrintList.FirstOrDefault(f=>f.Id == SelectedPrintListItemId);
      

         public ActionPageViewModel(MainViewModel mainViewModel,DialogService dialogService) : base(ApplicationPageNames.Action)
         {
             this.mainViewModel = mainViewModel;
             this.dialogService = dialogService;

             FetchPrintActionsData();
         }

       
       public void RefreshActionPage(ApplicationTabActionPage actionPage)
       {
           switch ((actionPage))
           {
               case ApplicationTabActionPage.Print: FetchPrintActionsData();
                   break;
           }
       }

       [RelayCommand]
       private void FetchPrintActionsData()
       {
           PrinterProfile =
           [
               _defaultPrinterProfile,
               new ActionPrinterProfileViewModel { Name = "Print Landscape",Description = "Print All file in landscape mode,3 copies",Coppies = 3,Id = "1"},
               new ActionPrinterProfileViewModel { Name = "Print Portrait",Description = "Print All file in portrait mode,1 copies",Coppies = 1,Id = "2"},
               new ActionPrinterProfileViewModel { Name = "B&W A3",Description = "Make all A3 prints black and white",Coppies = 5,Id = "3"}
           ];
           // TODO : Fetch from a database/service provider 
           PrintList =
           [
               new ActionPrintViewModel { Id= "1", Jobname = "Print Only Drawings" ,PrintDrawings = true,Description = "Prints Only Drawing Files",PrintDrawingRange = "0,5,7-8",PrinterProfileID = "1"},
               new ActionPrintViewModel { Id = "2", Jobname = "Print All Drawings Scale To Fit" ,Description = "Prints drawing scaled to fit the paper",PrintDrawings = true,PrinterProfileID ="2"},
               new ActionPrintViewModel { Id = "3", Jobname = "Print 3D Model A3" ,Description = "Prints model as 3D visuals",PrintModels = true,PrinterProfileID = "3"},
           ];
           // Update PrintListHasItem when collection changes
           PrintList.CollectionChanged += (_,_)=> OnPropertyChanged(nameof(PrintListHasItems));
           
           if (PrintList.Count > 0)
           {
               // Select first item
               SelectedPrintListItemId = PrintList.First().Id;
               // Store last fetched database save states
               foreach (var printItem in PrintList)
               {
                   printItem.SetSavedState();
               }
           }
           
         
       }

       
       protected override void OnDesignTimeConstructor() 
       {
           FetchPrintActionsData();
       }

       [RelayCommand]
       public async Task DeletePrintList(string id)
       {
           // TODO : Pass this logic to a service that handles the database/storage/fetching
           //    For now just do it direct in here
           if (PrintList.Count(x => x.Id == id) != 1)
               // TODO : Throw/Warn?
               return;
           //Remove Item
           await DeletePrintItemFromUIAsync(id);


       }
        [RelayCommand]
       public void AddNewPrintList()
       {
           // Create a new item
           var newItem = new ActionPrintViewModel
           {
               Id = Guid.NewGuid().ToString("N"),
               Jobname= "New Print Item",
              
               IsNewItem = true,
               PrinterProfileID = "0"
           };
          
         
           // Add to the print list
           PrintList.Add(newItem);
           SelectedPrintListItemId = newItem.Id;
       }

       [RelayCommand]
       public async Task CacelPrintItem()
       {
           //Ignore if nothing is selected
           if (SelectedPrintListItem==null)
                return;
           if(SelectedPrintListItem.IsNewItem)
              await DeletePrintItemFromUIAsync(SelectedPrintListItem.Id);
           else
           {
               SelectedPrintListItem.RestoreSavedState();
           }
       }
       // ReSharper disable once InconsistentNaming

       private async Task DeletePrintItemFromUIAsync(string id)
       {
           var index = PrintList.IndexOf(PrintList.First(x => x.Id == id));
           var confirmDelete = new ConfirmDialogViewModel
           {
               Title = $"Delete {PrintList[index].Jobname}?",
               Message = "Are you sure you want to delete this print?"
           };
           await dialogService.ShowDialog(mainViewModel, confirmDelete);
          if (!confirmDelete.Confirmed)
              return;
           PrintList.RemoveAt(index);
           if (index > 0) index--;
           if (PrintList.Count > 0)
               SelectedPrintListItemId=PrintList[index].Id ;
       }
     }