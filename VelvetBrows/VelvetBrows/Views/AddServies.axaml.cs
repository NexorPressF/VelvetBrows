using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using VelvetBrows.Classes;
using VelvetBrows.Data;

namespace VelvetBrows.Views;

public partial class AddServies : UserControl
{
    public int _id;
    public AddServies(int id = -1)
    {
        InitializeComponent();
        _id = id;
        if (id == -1)
        {
            MainSp.DataContext = new Service();
        }
        else
        {
            var service = Help.TC.Services.FirstOrDefault(el => el.Id == id);
            MainSp.DataContext = service;
        }
    }

    private void CancelBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Help.MCC.Content = new AdminView();
    }

    private void OkBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (_id == -1)
        {
            Help.TC.Services.Add(MainSp.DataContext as Service);
        }
        Help.TC.SaveChanges();
        Help.MCC.Content = new AdminView();
    }
}