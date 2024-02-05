using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.ValueObjects
{
    public sealed record MaxCapacity
    {
        public int Value { get; init; }

        private MaxCapacity(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Capacity should be greater than 0.");
            }

            Value = value;
        }

        public static MaxCapacity Create(int value)
        {
            return new MaxCapacity(value);
        }

        public static implicit operator int(MaxCapacity value)
        {
            return value.Value;
        }
    }
}
