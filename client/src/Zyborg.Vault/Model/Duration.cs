using System;

namespace Zyborg.Vault.Model
{
    public struct Duration
    {
        private TimeSpan _duration;

        public override string ToString()
        {
            return ((long)_duration.TotalSeconds).ToString();
        }

        public long TotalSeconds => (long)_duration.TotalSeconds;
        public long TotalMinutes => (long)_duration.TotalMinutes;
        public long TotalHours => (long)_duration.TotalHours;

        public static Duration FromSeconds(long s) =>
                new Duration { _duration = TimeSpan.FromSeconds(s) };

        public static Duration FromMinutes(long m) =>
                new Duration { _duration = TimeSpan.FromMinutes(m) };

        public static Duration FromHours(long h) =>
                new Duration { _duration = TimeSpan.FromHours(h) };

        public static implicit operator Duration(TimeSpan timeSpan)
        {
            return new Duration { _duration = timeSpan };
        }

        public static implicit operator Duration(string spec)
        {
            if (spec == null)
                return null;

            Func<double, TimeSpan> fromSpec = TimeSpan.FromSeconds;

            if (spec.EndsWith("s", StringComparison.OrdinalIgnoreCase))
            {
                spec = spec.TrimEnd('s','S');
            }
            else if (spec.EndsWith("m", StringComparison.OrdinalIgnoreCase))
            {
                fromSpec = TimeSpan.FromMinutes;
                spec = spec.TrimEnd('m', 'M');
            }
            else if (spec.EndsWith("h", StringComparison.OrdinalIgnoreCase))
            {
                fromSpec = TimeSpan.FromHours;
                spec = spec.Trim('h', 'H');
            }

            return new Duration { _duration = fromSpec(double.Parse(spec.Trim())) };
        }

        public static implicit operator Duration(int s)
        {
            return FromSeconds(s);
        }

        public static implicit operator Duration(long s)
        {
            return FromSeconds(s);
        }

        public static implicit operator string(Duration d)
        {
            return d.ToString();
        }

        public static implicit operator string(Duration? d)
        {
            return d?.ToString();
        }

        public static implicit operator int(Duration? d)
        {
            return d.HasValue ? (int)d.Value._duration.TotalSeconds : 0;
        }

        public static implicit operator long(Duration? d)
        {
            return d.HasValue ? (long)d.Value._duration.TotalSeconds : 0L;
        }        
    }
}