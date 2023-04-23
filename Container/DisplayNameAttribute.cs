using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Common;
using System.Reflection;
using System.ComponentModel;

namespace UQuery.Container
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DisplayNameAttribute : Attribute
    {
        public DisplayNameAttribute(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
    }
}