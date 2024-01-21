using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Timer = System.Timers.Timer;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Reflection;
using System.Threading;

namespace timer.Data.MyCustomTimer
{
    internal class MyTimer
    {
        private readonly Timer _timer;
        private readonly MyClock? _myClock;
        private TimeSpan _timeNow;
        private TimeSpan _timeStart;
        private TimeSpan _timeEnd;
        private TimeSpan _timeRange;
        private TimeSpan _interval;
        private Action? _actionBody;
        private Action? _actionAfter;

        private TimeSpan Now => DateTime.Now.TimeOfDay;
        public DateTime GetDateTimeInterval() => new DateTime(0, 0, _interval.Days, _interval.Hours, _interval.Minutes, _interval.Seconds, Math.Abs(_interval.Milliseconds));
        public TimeSpan GetInterval() { return _interval; }
        public TimeOnly GetIntervalTimeOnly() { return new TimeOnly(_interval.Hours, _interval.Minutes, _interval.Seconds, Math.Abs(_interval.Milliseconds)); }
        public DateTimeOffset GetDateTimeOffset()
        {
            return new DateTimeOffset(0, 0, 0, _interval.Hours, _interval.Minutes, _interval.Seconds, Math.Abs(_interval.Milliseconds), new TimeSpan(1, 0, 0));
        }
        public MyClock GetIntervalMyClock() => new MyClock(_interval);
        public MyTimer()
        {
            _timer = new Timer();
        }
        public MyTimer(TimeSpan timeSpanInterval, MyClock timeRange)
        {
            _timer = new Timer(timeSpanInterval);
            _timeRange = timeRange.GetTimeSpan;
        }
        public MyTimer(TimeSpan timeSpanInterval, TimeSpan timeRange)
        {
            _timer = new Timer(timeSpanInterval);
            _timeRange = timeRange;
        }
        public MyTimer(TimeSpan timeSpanInterval, DateTimeOffset timeRange)
        {
            _timer = new Timer(timeSpanInterval);
            _timeRange = new TimeSpan(timeRange.Hour, timeRange.Minute, timeRange.Second, timeRange.Millisecond);

        }
        public MyTimer(TimeSpan timeSpanInterval, TimeOnly timeRange)
        {
            _timer = new Timer(timeSpanInterval);
            _timeRange = timeRange.ToTimeSpan();
        }
        public MyTimer(int secondInterval, MyClock timeRange)
        {
            _timer = new Timer(secondInterval * 1000);
            _timeRange = timeRange.GetTimeSpan;
        }
        public MyTimer(double milisecondInterval, MyClock timeRange)
        {
            _timer = new Timer(milisecondInterval);
            _myClock = timeRange;
        }
        public MyTimer(Timer newTimer, MyClock timeRange)
        {
            _timer = newTimer;
            _myClock = timeRange;
        }
        public MyTimer(Timer newTimer, TimeSpan timeout, MyClock timeRange)
        {
            if (_timer != null)
            {
                _timer.Interval = timeout.TotalMicroseconds;
            }
            _timer = newTimer;
            _myClock = timeRange;
        }
        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            _timeNow = Now;
            _interval = _timeEnd - _timeNow;

            _actionBody?.Invoke();

            if (_timeNow >= _timeEnd)
            {
                _timer.Stop();
                _actionAfter?.Invoke();
            }

        }
        public void Start<Type>(Action? actBody)
        {
            _actionBody = actBody;

            _timer.Enabled = true;
            _timer.AutoReset = true;

            _timeStart = Now;
            _timeEnd = _timeRange + _timeStart;

            _timer.Elapsed += Timer_Elapsed;
        }

        public void Start(Action? actBody, Action? actAfterEnd)
        {
            _actionBody = actBody;
            _actionAfter = actAfterEnd;

            _timer.Enabled = true;
            _timer.AutoReset = true;

            _timeStart = Now;
            _timeEnd = _timeRange + _timeStart;

            _timer.Elapsed += Timer_Elapsed;

            //Console.ReadLine();
        }
    }
}
