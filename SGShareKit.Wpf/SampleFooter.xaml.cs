﻿using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SlimGis.Sharedkits.Wpf
{
    /// <summary>
    /// Interaction logic for Footer.xaml
    /// </summary>
    public partial class SampleFooter : Control
    {
        public SampleFooter()
        {
            InitializeComponent();
        }

        private void QuestionButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://forums.slimgis.com/");
        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Application.Current.MainWindow, "Please send email to \"support@slimgis.com\".", "Contact us", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.slimgis.com/");
        }

        private void LearnMoreButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://blog.slimgis.com/");
        }
    }
}
