using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JMap.Tests
{
    [TypeConverter(typeof(UrlTypeConverter))]
    public struct Url
    {
        public static explicit operator Url(string text) => new Url(text, true);
        public static implicit operator string(Url url) => url.Text;

        public Url(string text, bool validate)
            : this()
        {
            if (String.IsNullOrWhiteSpace(text))
                return;

            Text = text;
            if(validate)
                new WebResource()
                    .ValidateUrl(this);
        }

        public string Text { get; }
        public bool Empty => Text == null;
        public override string ToString() => Text;
        public override bool Equals(object obj) => Text == obj?.ToString();
        public override int GetHashCode() => Text?.GetHashCode() ?? 0;
    }
}
