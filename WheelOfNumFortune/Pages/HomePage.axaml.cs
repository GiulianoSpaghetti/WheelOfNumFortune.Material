using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using WheelOfNumFortune.ViewModels;

namespace WheelOfNumFortune.Pages;

public partial class HomePage : UserControl
{
    public HomePage()
    {
        DataContext ??= new MainViewModel();
        InitializeComponent();
    }
}