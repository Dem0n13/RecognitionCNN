using System;
using System.Threading.Tasks;
using System.Timers;

namespace Recognition.Utils
{
    // TODO
    public class ActionRepeater
    {
        private const double MinRepeaterPeriod = 250.0;
        private const double MaxRepeaterPeriod = 4000.0;
        private readonly Timer _timer;
        private readonly Action _action;

        public bool Started { get; set; }

        public ActionRepeater(Action action, double period)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            if (!(MinRepeaterPeriod <= period && period <= MaxRepeaterPeriod))
                throw new ArgumentException("Invalid period", "period");

            _timer = new Timer(period);
            _action = action;
        }

        public void Start(bool startInvoke)
        {
            Started = true;
            _timer.Elapsed += OnTimerElapsed;
            if (startInvoke) OnTimerElapsed(null, null);
            _timer.Start();
        }

        public void Stop(bool stopInvoke)
        {
            _timer.Elapsed -= OnTimerElapsed;
            _timer.Stop();
            if (stopInvoke) OnTimerElapsed(null, null);
            Started = false;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _action();
        }

        public void IncPeriod()
        {
            var newValue = _timer.Interval*2.0;
            if (newValue > MaxRepeaterPeriod) return;
            _timer.Interval = newValue;
        }

        public void DecPeriod()
        {
            var newValue = _timer.Interval/2.0;
            if (newValue < MinRepeaterPeriod) return;
            _timer.Interval = newValue;
        }
    }
}
