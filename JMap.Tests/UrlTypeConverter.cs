using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMap.Tests
{
    class UrlTypeConverter : TypeConverter
    {
        public UrlTypeConverter(Type type)
        {
            Type = type;
        }

        Type Type { get; }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return
                sourceType == typeof(string) ||
                base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null || value is string)
                return Activator.CreateInstance(Type, value, true);

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return
                destinationType == typeof(string) ||
                base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
                return value?.ToString();

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
