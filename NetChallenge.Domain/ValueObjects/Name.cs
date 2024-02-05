using NetChallenge.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetChallenge.Domain.ValueObjects
{
    public sealed record Name
    {
        public string Value { get; init; }

        private Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }

            Value = value;
        }

        public static Name Create(string value)
        {
            return new Name(value);
        }

        public static implicit operator string(Name value) 
        { 
            return value.Value;
        }
    }
}
