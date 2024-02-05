using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.ValueObjects
{
    public sealed record Duration
    {
        public TimeSpan Value { get; init; }

        private Duration(TimeSpan value)
        {
            if (value <= TimeSpan.Zero)
            {
                throw new ArgumentException("Duration should be greater than 0.");
            }

            Value = value;
        }

        public static Duration Create(TimeSpan value)
        {
            return new Duration(value);
        }

        public static implicit operator TimeSpan(Duration value)
        {
            return value.Value;
        }
    }
}
