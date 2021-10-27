using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfControlsDemo.ViewModel
{
    public class BadgeViewModel : ViewModelBase
    {
        private int _Count;
        public int Count
        {
            get
            {
                return _Count;
            }
            set
            {
                _Count = value;
                RaisePropertyChanged();
                RaisePropertyChanged("Text");
                RaisePropertyChanged("Show");
            }
        }

        public string Text
        {
            get
            {
                return Count > 99 ? "99+" : (Count > 0 ? $"{Count}" : " ");
            }
        }

        public bool Show
        {
            get
            {
                return Count > 0;
            }
        }

        private readonly Random _Rand;
        private bool _Incr;

        public BadgeViewModel()
        {
            _Rand = new Random();
            Count = _Rand.Next(1, 10);
            _Incr = true;
        }

        private DelegateCommand _TestBadge = null;
        public DelegateCommand TestBadge
        {
            get
            {
                return _TestBadge ?? (_TestBadge = new DelegateCommand(
                    async (obj) =>
                    {
                        if (Count < 0)
                        {
                            Count = 1;
                            _Incr = true;
                        }
                        else if(_Incr)
                        {
                            Count += _Rand.Next(10, 50);
                            if(Count > 100)
                            {
                                _Incr = false;
                            }
                        }
                        else
                        {
                            Count -= _Rand.Next(10, 50);
                        }
                    }));
            }
        }
    }
}

