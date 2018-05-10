using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting.Infrastructure.Extensions
{
    public class IdAttribute : Attribute
    {
        public IdAttribute(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}
