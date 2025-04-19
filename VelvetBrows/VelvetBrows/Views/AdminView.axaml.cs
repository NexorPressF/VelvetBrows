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
        FCB.SelectedIndex = 0;
        LoadData();
        

    }

    private void LoadData()
    {
        Help.TC.Services.Load();
        if (FCB.SelectedIndex == 0)
        {
            ODB.ItemsSource = Help.TC.Services.ToList(); 
        }
        if (FCB.SelectedIndex == 1)
        {
            ODB.ItemsSource = Help.TC.Services.Where(el => el.Discount >= 0 && el.Discount < 5).ToList();
        }
        if (FCB.SelectedIndex == 2)
        {
            ODB.ItemsSource = Help.TC.Services.Where(el => el.Discount >= 5 && el.Discount < 15).ToList();
        }
        if (FCB.SelectedIndex == 3)
        {
            ODB.ItemsSource = Help.TC.Services.Where(el => el.Discount >= 15 && el.Discount < 30).ToList();
        }
        if (FCB.SelectedIndex == 4)
        {
            ODB.ItemsSource = Help.TC.Services.Where(el => el.Discount >= 30 && el.Discount < 70).ToList();
        }
        if (FCB.SelectedIndex == 5)
        {
            ODB.ItemsSource = Help.TC.Services.Where(el => el.Discount >= 70 && el.Discount < 100).ToList();
        }
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

    private void FCB_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        LoadData();
    }
}