using System.Threading;
using System.Threading.Tasks;

namespace WpfControlsDemo.ViewModel
{
    public class BusyMaskViewModel:ViewModelBase
    {
        private bool isBusy = false;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }

        private bool canStartTest;
        public bool CanStartTest
        {
            get
            {
                return canStartTest;
            }
            set
            {
                canStartTest = value;
                RaisePropertyChanged();
            }
        }

        public BusyMaskViewModel()
        {
            IsBusy = false;
            CanStartTest = true;
        }

        private DelegateCommand testBusy = null;
        public DelegateCommand TestBusy
        {
            get
            {
                return testBusy ?? (testBusy = new DelegateCommand(
                    async (obj) =>
                    {
                        IsBusy = true;
                        CanStartTest = false;
                        await Task.Run(() => { Thread.Sleep(5000); });
                        IsBusy = false;
                        CanStartTest = true;
                    }));
            }
        }
    }
}
