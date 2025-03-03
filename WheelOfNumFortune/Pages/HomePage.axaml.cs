using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using WheelOfNumFortune.ViewModels;

namespace WheelOfNumFortune.Pages;

public partial class HomePage : UserControl
{
    private static string s;
    public HomePage()
    {
        InitializeComponent();
        OnTick_Click(null, null);
    }



    public void OnTick_Click(object obj, RoutedEventArgs args)
    {

        s = MainViewModel.Tick();
        lblStatus.Text = "";
        if (MainViewModel.ObtainedResponse())
        {
            txtCookie.Text = s;
            txtSolution.Text = "";
            txtSolution.IsEnabled = true;
            btnDiscover.IsEnabled = true;
            btnCheck.IsEnabled = true;
        }
        else
        {
            lblStatus.Text = s;
            txtSolution.IsEnabled = false;
            btnDiscover.IsEnabled = false;
            btnCheck.IsEnabled = false;

        }
    }
    public void CheckSolution_Click(object sender, RoutedEventArgs e)
    {
        if (MainViewModel.CheckRisposta(txtSolution.Text))
        {
            lblStatus.Text = "You are right";
            txtSolution.IsEnabled = false;
            btnDiscover.IsEnabled = false;
            btnCheck.IsEnabled = false;
        }
        else
        {
            lblStatus.Text = "You are wrong";
        }
    }

    public void DiscoverLetter_Click(object sender, RoutedEventArgs e)
    {
        lblStatus.Text = "";
        if (MainViewModel.DiscoverLetter())
            txtCookie.Text = MainViewModel.getVisualizzazione();
        else
        {
            lblStatus.Text = "You lost";
            txtSolution.IsEnabled = false;
            btnDiscover.IsEnabled = false;
            btnCheck.IsEnabled = false;

        }
    }
}