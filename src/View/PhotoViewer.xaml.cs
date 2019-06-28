using System;
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

using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using Microsoft.Win32;

namespace WpfControlsDemo.View
{
    /// <summary>
    /// Interaction logic for PhotoViewer.xaml
    /// </summary>
    public partial class PhotoViewer : Page
    {
        public PhotoViewer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image|*.jpg;*.png;*.tif;*.bmp";
            ofd.Multiselect = false;
            ofd.Title = "Select a picture";
            if(ofd.ShowDialog().Value)
            {
                ImageWidget.Source = LoadBitmapImage(ofd.FileName);
            }
        }

        private static BitmapImage LoadBitmapImage(string file)
        {
            using (var stream = new MemoryStream())
            {
                Bitmap bitmap = new Bitmap(file);
                bitmap.Save(stream, ImageFormat.Png); 
                stream.Position = 0;
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.CacheOption = BitmapCacheOption.OnLoad;
                bm.StreamSource = stream;
                bm.EndInit();
                bm.Freeze();

                return bm;
            }
        }

    }
}
