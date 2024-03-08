using Avalonia.Controls;
using Avalonia.Interactivity;
using MessageBox.Controls;

namespace MessageBox.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Controls.MessageBox messageBox = new Controls.MessageBox()
        {
            Title = "Hello World",
            Message = "Hello World!",
            Buttons = MessageBoxButtons.OKCancel
        };
        Panel.Children.Add(messageBox);
    }
}