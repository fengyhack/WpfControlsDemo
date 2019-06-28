﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControlsDemo.View
{
    /// <summary>
    /// Interaction logic for LoginFlyout.xaml
    /// </summary>
    public partial class LoginFlyout : Page
    {
        public LoginFlyout()
        {
            InitializeComponent();
            flyout.IsOpen = false;
        }

        private void Button_Confirm_Click(object sender, RoutedEventArgs e)
        {
            flyout.IsOpen = false;
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            flyout.IsOpen = false;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            flyout.IsOpen = true;
        }
    }
}
