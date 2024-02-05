using NetChallenge.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.ValueObjects
{
    public sealed class Neighborhood
    {
        public string Value { get; private set; }

        private Neighborhood(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Neighborhood cannot be null or empty.");
            }

            Value = value;
        }

        public static Neighborhood Create(string value)
        {
            return new Neighborhood(value);
        }

        public static implicit operator string(Neighborhood value)
        {
            return value.Value;
        }
    }
}
