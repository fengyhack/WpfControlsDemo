using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfControlsDemo.ViewModel
{
    public class ViewModelBase:INotifyPropertyChanged
    {
        #region INotifyPaopertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPaopertyChanged
    }
}
