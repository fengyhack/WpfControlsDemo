using System;
using System.Windows;
using System.Windows.Controls;

using System.Collections.ObjectModel;

namespace WpfControlsDemo.View
{
    /// <summary>
    /// Interaction logic for TimelineView.xaml
    /// </summary>
    public partial class TimelineView : Page
    {
        private ObservableCollection<DataItem> itemList = null;

        public TimelineView()
        {
            InitializeComponent();

            InitDataItems();

            timeline.ItemsSource = itemList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataItems();
        }

        private string text = "Something happend at some place.";
        private const int COUNT = 5;
        private bool add = false;

        private void InitDataItems()
        {
            itemList = new ObservableCollection<DataItem>();

            var time = DateTime.Now.AddMonths(-10);

            for (int i = 0; i < COUNT; ++i)
            {

                itemList.Add(new DataItem()
                {
                    Time = time,
                    Text = text
                });
                time = time.AddHours(1.5);
            }
        }

        private void UpdateDataItems()
        {
            var time = DateTime.Now.AddMonths(-10);

            if (add)
            {
                itemList.Insert(1, new DataItem()
                {
                    Time = time,
                    Text = "Something happend at some place."
                });
                itemList.Insert(2, new DataItem()
                {
                    Time = time,
                    Text = "Something happend at some place."
                });
            }
            else
            {
                itemList.RemoveAt(COUNT-1);
                itemList.RemoveAt(1);
            }

            foreach (var item in itemList)
            {
                item.Time = item.Time.AddHours(1);
                item.Text = "Nothing" + text.Substring("Something".Length);
            }

            add = !add;
        }
    }

    public class DataItem
    {
        public DateTime Time { get; set; }

        public string Text { get; set; }
    }
}
