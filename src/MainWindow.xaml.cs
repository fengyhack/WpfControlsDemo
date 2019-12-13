using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfControlsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, object> contentDict = null;

        public MainWindow()
        {
            InitializeComponent();

            contentDict = new Dictionary<string, object>();
            InitControls();         
        }

        private void InitControls()
        {
            var busyMaskView = new View.BusyMaskView();
            var nodeTreeView = new View.NodeTreeView();
            var photoViewer = new View.PhotoViewer();
            var loginFlyout = new View.LoginFlyout();
            var imageButtons = new View.ImageButtons();
            var timelineView = new View.TimelineView();
            var stepBarView = new View.StepBarView();
            var inputBoxView = new View.InputBoxView();
            var solidGauge = new View.SolidGauge();
            var scrollView = new View.ScrollView();
            contentDict.Add("Empty", null);
            contentDict.Add("BusyMask", busyMaskView);
            contentDict.Add("TreeView", nodeTreeView);
            contentDict.Add("PhotoViewer", photoViewer);
            contentDict.Add("LoginFlyout", loginFlyout);
            contentDict.Add("ImageButtons", imageButtons);
            contentDict.Add("Timeline", timelineView);
            contentDict.Add("StepBar", stepBarView);
            contentDict.Add("InputBox", inputBoxView);
            contentDict.Add("SolidGauge", solidGauge);
            contentDict.Add("ScrollView", scrollView);

            listBox.ItemsSource = contentDict.Keys;
            listBox.SelectedIndex = 0;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex < 0) return;

            string cstr = listBox.SelectedItem.ToString();
            frameHost.Content = contentDict[cstr];
        }
    }
}
