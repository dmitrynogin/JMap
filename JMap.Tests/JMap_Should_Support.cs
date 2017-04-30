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
        public async Task Boolean()
        {
            var values = new Values();
            await JObject.MapAsync()
                .Required((bool boolean) => values.Boolean);

            Assert.AreEqual(true, values.Boolean);
        }

        [TestMethod]
        public async Task Integer()
        {
            var values = new Values();
            await JObject.MapAsync()
                .Required((int integer) => values.Byte)
                .Required((int integer) => values.Int32)
                .Required((int integer) => values.Int64);

            Assert.AreEqual(123, values.Byte);
            Assert.AreEqual(123, values.Int32);
            Assert.AreEqual(123, values.Int64);

            await JObject.MapAsync()
                .Required((long integer) => values.Byte)
                .Required((long integer) => values.Int32)
                .Required((long integer) => values.Int64);

            Assert.AreEqual(123, values.Byte);
            Assert.AreEqual(123, values.Int32);
            Assert.AreEqual(123, values.Int64);
        }

        [TestMethod]
        public async Task Real()
        {
            var values = new Values();
            await JObject.MapAsync()
                .Required((float real) => values.Float)
                .Required((float real) => values.Double)
                .Required((float real) => values.Decimal);

            Assert.AreEqual(123.123, values.Float, 0.0001);
            Assert.AreEqual(123.123, values.Double, 0.0001);
            Assert.AreEqual(123.123m, values.Decimal);

            await JObject.MapAsync()
                .Required((double real) => values.Float)
                .Required((double real) => values.Double)
                .Required((double real) => values.Decimal);

            Assert.AreEqual(123.123, values.Float, 0.0001);
            Assert.AreEqual(123.123, values.Double, 0.0001);
            Assert.AreEqual(123.123m, values.Decimal);
        }

        [TestMethod]
        public async Task DateTime()
        {
            var values = new Values();
            await JObject.MapAsync()
                .Required((DateTime dateTime) => values.DateTime);

            Assert.AreEqual(new DateTime(2016, 03, 20, 22, 19, 01), values.DateTime);
        }

        [TestMethod]
        public async Task Url()
        {
            var values = new Values();
            await JObject.MapAsync()
                .Required((string url) => values.Url);

            Assert.AreEqual((Url)"http://www.microsoft.com", values.Url);
        }

        [TestMethod]
        public async Task NullableBoolean()
        {
            var values = new NullableValues();
            await JObject.MapAsync()
                .Required((bool? nullValue) => values.Boolean);

            Assert.IsNull(values.Boolean);
        }

        [TestMethod]
        public async Task NullableInteger()
        {
            var values = new NullableValues();

            await JObject.MapAsync()
                .Required((int? nullValue) => values.Byte)
                .Required((int? nullValue) => values.Int32)
                .Required((int? nullValue) => values.Int64);

            Assert.IsNull(values.Byte);
            Assert.IsNull(values.Int32);
            Assert.IsNull(values.Int64);

            await JObject.MapAsync()
                .Required((long? nullValue) => values.Byte)
                .Required((long? nullValue) => values.Int32)
                .Required((long? nullValue) => values.Int64);

            Assert.IsNull(values.Byte);
            Assert.IsNull(values.Int32);
            Assert.IsNull(values.Int64);
        }

        [TestMethod]
        public async Task NullableReal()
        {
            var values = new NullableValues();

            await JObject.MapAsync()
                .Required((float? nullValue) => values.Float)
                .Required((float? nullValue) => values.Double)
                .Required((float? nullValue) => values.Decimal);

            Assert.IsNull(values.Float);
            Assert.IsNull(values.Double);
            Assert.IsNull(values.Decimal);

            await JObject.MapAsync()
                .Required((double? nullValue) => values.Float)
                .Required((double? nullValue) => values.Double)
                .Required((double? nullValue) => values.Decimal);

            Assert.IsNull(values.Float);
            Assert.IsNull(values.Double);
            Assert.IsNull(values.Decimal);
        }

        [TestMethod]
        public async Task NullableDateTime()
        {
            var values = new NullableValues();
            await JObject.MapAsync()
                .Required((DateTime? nullValue) => values.DateTime);

            Assert.IsNull(values.DateTime);
        }

        [TestMethod]
        public async Task NullableUrl()
        {
            var values = new NullableValues();
            await JObject.MapAsync()
                .Required((string nullValue) => values.Url);

            Assert.IsNull(values.Url);
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

        public Url Url { get; set; }
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

        public Url? Url { get; set; } = (Url)"http://www.intel.com";
    }
}
