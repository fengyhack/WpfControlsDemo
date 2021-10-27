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
        private bool add = false;
        private int count = 0;
        private Random rand = new Random();

        private void InitDataItems()
        {
            itemList = new ObservableCollection<DataItem>();

            var time = DateTime.Now.AddMonths(-10);

            count = 5;
            for (int i = 0; i < count; ++i)
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
            var time = itemList.Count > 0 ? itemList[0].Time : DateTime.Now.AddMonths(-10);

            if (add)
            {
                itemList.Insert(0, new DataItem()
                {
                    Time = time.AddDays(-1),
                    Text = "Something happend at some place."
                });
                itemList.Insert(0, new DataItem()
                {
                    Time = time.AddDays(-2),
                    Text = "Something happend at some place."
                });
                count += 2;
                timeline.ItemsSource = null;
                timeline.ItemsSource = itemList;
            }
            else
            {
                if (count > 1)
                {
                    itemList.RemoveAt(count - 1);
                    --count;
                }
                timeline.ItemsSource = null;
                timeline.ItemsSource = itemList;
            }

            foreach (var item in itemList)
            {
                item.Time = item.Time.AddHours(1);
                item.Text = "Nothing" + text.Substring("Something".Length);
            }

            add = count < 2 || rand.Next(100) > 70;
        }
    }

    public class DataItem
    {
        public DateTime Time { get; set; }

        public string Text { get; set; }
    }
}
