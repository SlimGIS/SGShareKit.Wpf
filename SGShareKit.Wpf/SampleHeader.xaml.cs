using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SlimGis.Sharedkits.Wpf
{
    /// <summary>
    /// Interaction logic for SampleHeader.xaml
    /// </summary>
    public partial class SampleHeader : Control
    {
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(SampleHeader), new PropertyMetadata(new BitmapImage(new Uri("pack://application:,,,/SGShareKit.Wpf;Component/Images/SlimGIS-Logo-40.png", UriKind.RelativeOrAbsolute))));

        public SampleHeader()
        {
            InitializeComponent();
        }

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
    }
}
