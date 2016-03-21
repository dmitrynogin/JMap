using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMap.Tests
{
    [TestClass]
    public class JMap_Should_Support
    {
        public JMap_Should_Support()
        {
            var json = File.ReadAllText("types.json");
            JObject = JObject.Parse(json);
        }

        JObject JObject { get; }

        [TestMethod]
        public void Boolean()
        {
            var values = new Values();
            JObject.Required((bool boolean) => values.Boolean);
            Assert.AreEqual(true, values.Boolean);
        }

        [TestMethod]
        public void Integer()
        {
            var values = new Values();
            JObject.Required((int integer) => values.Byte);
            JObject.Required((int integer) => values.Int32);
            JObject.Required((int integer) => values.Int64);
            Assert.AreEqual(123, values.Byte);
            Assert.AreEqual(123, values.Int32);
            Assert.AreEqual(123, values.Int64);

            JObject.Required((long integer) => values.Byte);
            JObject.Required((long integer) => values.Int32);
            JObject.Required((long integer) => values.Int64);
            Assert.AreEqual(123, values.Byte);
            Assert.AreEqual(123, values.Int32);
            Assert.AreEqual(123, values.Int64);
        }

        [TestMethod]
        public void Real()
        {
            var values = new Values();
            JObject.Required((float real) => values.Float);
            JObject.Required((float real) => values.Double);
            JObject.Required((float real) => values.Decimal);
            Assert.AreEqual(123.123, values.Float, 0.0001);
            Assert.AreEqual(123.123, values.Double, 0.0001);
            Assert.AreEqual(123.123m, values.Decimal);

            JObject.Required((double real) => values.Float);
            JObject.Required((double real) => values.Double);
            JObject.Required((double real) => values.Decimal);
            Assert.AreEqual(123.123, values.Float, 0.0001);
            Assert.AreEqual(123.123, values.Double, 0.0001);
            Assert.AreEqual(123.123m, values.Decimal);
        }

        [TestMethod]
        public void DateTime()
        {
            var values = new Values();
            JObject.Required((DateTime dateTime) => values.DateTime);
            Assert.AreEqual(new DateTime(2016, 03, 20, 22, 19, 01), values.DateTime);
        }


        [TestMethod]
        public void NullableBoolean()
        {
            var values = new NullableValues();
            JObject.Required((bool? nullValue) => values.Boolean);
            Assert.IsNull(values.Boolean);
        }

        [TestMethod]
        public void NullableInteger()
        {
            var values = new NullableValues();
            JObject.Required((int? nullValue) => values.Byte);
            JObject.Required((int? nullValue) => values.Int32);
            JObject.Required((int? nullValue) => values.Int64);
            Assert.IsNull(values.Byte);
            Assert.IsNull(values.Int32);
            Assert.IsNull(values.Int64);

            JObject.Required((long? nullValue) => values.Byte);
            JObject.Required((long? nullValue) => values.Int32);
            JObject.Required((long? nullValue) => values.Int64);
            Assert.IsNull(values.Byte);
            Assert.IsNull(values.Int32);
            Assert.IsNull(values.Int64);
        }

        [TestMethod]
        public void NullableReal()
        {
            var values = new NullableValues();
            JObject.Required((float? nullValue) => values.Float);
            JObject.Required((float? nullValue) => values.Double);
            JObject.Required((float? nullValue) => values.Decimal);
            Assert.IsNull(values.Float);
            Assert.IsNull(values.Double);
            Assert.IsNull(values.Decimal);

            JObject.Required((double? nullValue) => values.Float);
            JObject.Required((double? nullValue) => values.Double);
            JObject.Required((double? nullValue) => values.Decimal);
            Assert.IsNull(values.Float);
            Assert.IsNull(values.Double);
            Assert.IsNull(values.Decimal);
        }

        [TestMethod]
        public void NullableDateTime()
        {
            var values = new NullableValues();
            JObject.Required((DateTime? nullValue) => values.DateTime);
            Assert.IsNull(values.DateTime);
        }
    }

    class Values
    {
        public bool Boolean { get; set; }

        public byte Byte { get; set; }
        public int Int32 { get; set; }
        public int Int64 { get; set; }

        public float Float { get; set; }
        public double Double { get; set; }
        public decimal Decimal { get; set; }

        public DateTime DateTime { get; set; }
    }

    class NullableValues
    {
        public bool? Boolean { get; set; } = true;

        public byte? Byte { get; set; } = 33;
        public int? Int32 { get; set; } = 33;
        public int? Int64 { get; set; } = 33;

        public float? Float { get; set; } = 33;
        public double? Double { get; set; } = 33;
        public decimal? Decimal { get; set; } = 33m;

        public DateTime? DateTime { get; set; } = new DateTime(1999-12-31);
    }
}
