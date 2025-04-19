using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using VelvetBrows.Classes;
using VelvetBrows.Data;

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
        Help.MCC.Content = new AddServies();
    }

    private void RemakeBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var ser = ODB.SelectedItem as Service;
        if (ser == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Не выбран пользователь").ShowAsync();
            return;
        }

        Help.MCC.Content = new AddServies(ser.Id);
    }

    private void RemoveBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var ser = ODB.SelectedItem as Service;
        if (ser == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Не выбран пользователь").ShowAsync();
        }

        Help.TC.Services.Remove(ser);
        Help.TC.SaveChanges();
        Help.MCC.Content = new AdminView();
    }

    private void FindTb_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        ODB.ItemsSource = Help.TC.Services.Where(el => el.Description.Contains(FindTb.Text) || el.Title.Contains(FindTb.Text)).ToList();
    }
}