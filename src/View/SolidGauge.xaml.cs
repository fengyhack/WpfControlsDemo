using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfControlsDemo.View
{
    /// <summary>
    /// Interaction logic for SolidGauge.xaml
    /// </summary>
    public partial class SolidGauge : Page
    {
        private bool incr = true;

        public SolidGauge()
        {
            InitializeComponent();
            UpdateButton.Content = incr ? "Increase" : "Decrease";
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateAsync();            
        }


        private void UpdateAsync()
        {
            double progress = incr ? 0 : 100;
            double interval = incr ? 1 : -1;            

            Task.Run(new Action(
                () =>
                {
                    do
                    {
                        Dispatcher.Invoke(new Action(
                            () =>
                            {
                                progress += interval;
                                gauge1.Value = progress;
                                UpdateButton.IsEnabled = false;
                            }));
                        Thread.Sleep(15);
                    } while (progress < 100 && progress > 0);

                    incr = !incr;

                    Dispatcher.Invoke(new Action(
                            () =>
                            {
                                UpdateButton.Content = incr ? "Increase" : "Decrease";
                                UpdateButton.IsEnabled = true;
                            }));
                }));
        }
    }
}
