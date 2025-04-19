using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using VelvetBrows.Classes;

namespace VelvetBrows.Views;

public partial class AdminView : UserControl
{
    public AdminView()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        Help.TC.Services.Load();
        ODB.ItemsSource = Help.TC.Services.ToList();
    }

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void RemakeBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }
}