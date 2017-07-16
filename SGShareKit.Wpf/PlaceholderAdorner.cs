using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace SlimGis.ShareKit.Wpf
{
    public class PlaceholderAdorner : Adorner
    {
        private TextBox textBox;

        public PlaceholderAdorner(UIElement element)
            : base(element)
        {
            IsHitTestVisible = false;
            textBox = element as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged += delegate { InvalidateVisual(); };
                textBox.GotFocus += delegate { InvalidateVisual(); };
                textBox.LostFocus += delegate { InvalidateVisual(); };
                InvalidateVisual();
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (string.IsNullOrEmpty(textBox.Text) && !textBox.IsFocused)
            {
                Typeface typeface = textBox.FontFamily.GetTypefaces().FirstOrDefault();
                FormattedText formattedText = new FormattedText(PlaceholderAdorner.GetPlaceholder(textBox)
                    , CultureInfo.InvariantCulture
                    , textBox.FlowDirection
                    , new Typeface(typeface.FontFamily, FontStyles.Normal, FontWeights.Light, FontStretches.Normal)
                    , textBox.FontSize
                    , new SolidColorBrush(Colors.Gray));

                drawingContext.DrawText(formattedText, new Point(textBox.Padding.Left + 5, textBox.Padding.Top + 2));
            }
        }

        #region extensions
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached("Placeholder", typeof(string), typeof(PlaceholderAdorner), new PropertyMetadata("Please input value here.", OnPlaceholderPropertyChanged));

        public static string GetPlaceholder(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceholderProperty);
        }

        public static void SetPlaceholder(DependencyObject obj, string newText)
        {
            obj.SetValue(PlaceholderProperty, newText);
        }

        private static void OnPlaceholderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox newTextBox = d as TextBox;
            if (newTextBox != null)
            {
                newTextBox.Loaded += delegate
                {
                    PlaceholderAdorner adorner = new PlaceholderAdorner(newTextBox);
                    AdornerLayer.GetAdornerLayer(newTextBox).Add(adorner);
                };
            }
        }
        #endregion
    }
}
