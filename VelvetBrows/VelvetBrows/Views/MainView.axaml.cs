using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using VelvetBrows.Classes;

namespace VelvetBrows.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        LoadData();
        
    }

    private void LoadData()
    {
        Help.TC.Services.Load();
        MDG.ItemsSource = Help.TC.Services.ToList();
    }

    private void OkBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (CodeTb.Text == "0000")
        {
            Help.MCC.Content = new AdminView();
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Неправильный код пользователя").ShowAsync();
            CodeTb.Text = "";
            return;
        }
    }
}