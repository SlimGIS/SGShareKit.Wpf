﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SlimGis.ShareKit.Wpf
{
    /// <summary>
    /// Interaction logic for SampleHeader.xaml
    /// </summary>
    public partial class SampleHeader : Control
    {        
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(SampleHeader), new PropertyMetadata("SlimGIS MapKit Samples for WPF"));

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(SampleHeader), new PropertyMetadata(new BitmapImage(new Uri("pack://application:,,,/SGShareKit.Wpf;Component/Images/SlimGIS-Logo-40.png", UriKind.RelativeOrAbsolute))));

        public SampleHeader()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
    }
}
