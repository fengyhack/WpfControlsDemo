using System;
using System.Windows;

namespace WpfControlsDemo
{
    public class App : Application
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var w = new MainWindow();
            App app = new App();
            app.Run(w);
        }
    }
}
