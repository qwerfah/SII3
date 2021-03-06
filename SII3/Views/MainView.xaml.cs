﻿using SII3.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace SII3.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            Title = "Лабораторная работа №3";

            DataContext = new ApplicationViewModel();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
