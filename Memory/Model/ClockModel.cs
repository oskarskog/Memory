using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Memory.Model
{
    public class ClockModel : ObservableObjectBase
    {
        private DispatcherTimer _timer;
        private TimeSpan _second;
        private TimeSpan ElapsedTime;

        public ClockModel()
        {
            ElapsedTime = new TimeSpan(0, 0, 0);
            _second = new TimeSpan(0, 0, 1);
            _timer = new DispatcherTimer();
            _timer.Interval = _second;
            _timer.Tick += new EventHandler(OnTimerTick);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Reset()
        {
            ElapsedTime = new TimeSpan(0, 0, 0);
            NotifyPropertyChanged("ElapsedTime");
        }

        private void OnTimerTick(object o, EventArgs a)
        {
            ElapsedTime.Add(_second);
            NotifyPropertyChanged("ElapsedTime");
        }
    }
}
