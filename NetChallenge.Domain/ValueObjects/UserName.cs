using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.ValueObjects
{
    public sealed record UserName
    {
        public string Value { get; init; }

        private UserName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("UserName cannot be null or empty.");
            }

            Value = value;
        }

        public static UserName Create(string value)
        {
            return new UserName(value);
        }

        public static implicit operator string(UserName value)
        {
            return value.Value;
        }
    }
}
