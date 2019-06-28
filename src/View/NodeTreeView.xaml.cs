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
    /// Interaction logic for NodeTreeView.xaml
    /// </summary>
    public partial class NodeTreeView : Page
    {
        public List<NodeItem> Items = null;

        public NodeTreeView()
        {
            InitializeComponent();
            InitNodes();
            tv.ItemsSource = Items;
        }

        private void InitNodes()
        {
            Items = new List<NodeItem>();
            var node1 = new NodeItem() { Name = "Item1" };
            var node11 = new NodeItem() { Name = "Item11" };
            var node12 = new NodeItem() { Name = "Item12" };
            node1.Children.Add(node11);
            node1.Children.Add(node12);

            var node2 = new NodeItem() { Name = "Item2" };
            var node21 = new NodeItem() { Name = "Item21" };
            node2.Children.Add(node21);

            var node3 = new NodeItem() { Name = "Item3" };
            var node31 = new NodeItem() { Name = "Item31" };
            var node311 = new NodeItem() { Name = "Item311" };
            node31.Children.Add(node311);
            node3.Children.Add(node31);

            Items.Add(node1);
            Items.Add(node2);
            Items.Add(node3);
        }

        private void toggleButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var label = (Label)sender;
            var cp = (ContentPresenter)label.Tag;
            var tvi = (TreeViewItem)cp.TemplatedParent;
            tvi.IsExpanded = !tvi.IsExpanded;
        }
    }

    public class NodeItem
    {
        public string Name { get; set; }

        public List<NodeItem> Children { get; set; }

        public NodeItem()
        {
            Children = new List<NodeItem>();
        }
    }
}
