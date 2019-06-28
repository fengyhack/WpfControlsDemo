using System.Windows;
using System.Windows.Controls;

namespace WpfControlsDemo.View
{
    /// <summary>
    /// Interaction logic for ImageButtons.xaml
    /// </summary>
    public partial class ImageButtons : Page
    {
        public ImageButtons()
        {
            InitializeComponent();
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            var ib = (CuteWpfControls.ImageButton)sender;
            MessageBox.Show($"Button Image Source:\r\n{ib.ImagePath}", "ImageButton");
        }
    }
}
