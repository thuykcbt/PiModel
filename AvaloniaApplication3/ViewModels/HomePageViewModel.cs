using Avalonia.Media.Imaging;
using AvaloniaApplication3.Data;
using AvaloniaApplication3.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using HalconDotNet;
using System.IO;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication3.ViewModels;




public partial class HomePageViewModel:PageViewModel
{
    [ObservableProperty]  private Bitmap? _displayImage;
    HWindow hWindow_1 = new HWindow();
    HImage hImage = new HImage("E:\\Face_A.jpg");
   
   
    public HomePageViewModel() : base(ApplicationPageNames.Home)
    {
        
    }
    [RelayCommand]
    public void LoadHalconImage()
    {
        var dialog = new OpenFileDialog();
        dialog.Title = "Chọn file";
        dialog.AllowMultiple = false;

        dialog.Filters.Add(new FileDialogFilter()
        {
            Name = "Hình ảnh",
            Extensions = { "png", "jpg", "jpeg", "bmp" }
        });

   string result = "";

        if (result != null && result.Length > 0)
        {
            string filePath = result;
            HOperatorSet.ReadImage(out HObject ho_Image,filePath);
            // Convert HObject -> file -> Avalonia Bitmap
            HOperatorSet.WriteImage(ho_Image, "png", 0, "temp.png");
            using var fs = File.OpenRead("temp.png");
            DisplayImage = new Bitmap(fs);
        }
      
           
       
    
    }

    
}