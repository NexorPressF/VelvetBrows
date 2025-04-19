using Avalonia.Controls;
using Avalonia.Interactivity;
using VelvetBrows.Classes;

namespace VelvetBrows.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Help.MCC = MCC;
        Help.MCC.Content = new MainView();
    }


}