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

namespace WpfControlsDemo.View
{
    /// <summary>
    /// StepBarView.xaml 的交互逻辑
    /// </summary>
    public partial class StepBarView : Page
    {
        public StepBarView()
        {
            InitializeComponent();   
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            stepBar.Current = 0;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            --stepBar.Current;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ++stepBar.Current;
        }
    }
}
