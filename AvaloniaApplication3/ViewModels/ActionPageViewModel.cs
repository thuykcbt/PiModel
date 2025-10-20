using System;
 using System.Collections.ObjectModel;
 using AvaloniaApplication3.Data;
 using AvaloniaApplication3.ViewModels;
 using CommunityToolkit.Mvvm.ComponentModel;
 using CommunityToolkit.Mvvm.Input;
using System.Linq;

 namespace AvaloniaApplication3.ViewModels;
 
 public partial class ActionPageViewModel : PageViewModel
 {
     [ObservableProperty]
   private ObservableCollection<ActionPrintViewModel> _printList;
     public ActionPageViewModel() : base(ApplicationPageNames.Action)
     {
         FetchPrintList();
     }

   
   public void RefreshActionPage(ApplicationTabActionPage actionPage)
   {
       switch ((actionPage))
       {
           case ApplicationTabActionPage.Print: FetchPrintList();
               break;
       }
   }

   [RelayCommand]
   private void FetchPrintList()
   {
       // TODO : Fetch from a database/service provider 
       PrintList =
       [
           new ActionPrintViewModel { Id = "1", Jobname = "Print Only Drawings" ,IsSelected = false},
           new ActionPrintViewModel { Id = "2", Jobname = "Print All Drawings Scale To Fit" ,IsSelected = false},
           new ActionPrintViewModel { Id = "3", Jobname = "Print 3D Model A3",IsSelected = false },
       ];
   }

   
   protected override void OnDesignTimeConstructor() 
   {
       FetchPrintList();
   }

   [RelayCommand]
   public void DeletePrintList(string id)
   {
       // TODO : Pass this logic to a service that handles the database/storage/fetching
       //    For now just do it direct in here
       if (PrintList.Count(x => x.Id == id) != 1)
           // TODO : Throw/Warn?
           return;
       //Remove Item
       PrintList.Remove(_printList.First(x => x.Id == id));
     
       
   }
 }