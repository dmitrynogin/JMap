using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace JMap.Tests
{
    [TestClass]
    public class JMap_Should
    {
        public JMap_Should()
        {
            var json = File.ReadAllText("job.json");
            Job = JObject.Parse(json);
        }

        JObject Job { get; }

        [TestMethod]
        public async Task Map_Scalar()
        {            
            var dtoJob = new DtoJob { Title = "Empty" };
            await Job.MapAsync()
                .Optional((string title) => dtoJob.Title);

            Assert.AreEqual("tester", dtoJob.Title);            
        }

        [TestMethod]
        public async Task Map_Array()
        {
            var dtoJob = new DtoJob { Types = new[] { "Remote" } };
            await Job.MapAsync()
                .Optional((string[] types) => dtoJob.Types);

            CollectionAssert.AreEqual(new[] { "Full-Time", "Part-Time" }, dtoJob.Types.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public async Task Throw_On_Type_Mistmatch()
        {
            var dtoJob = new DtoJob { Title = "Empty" };
            await Job.MapAsync()
                .Optional((int title) => dtoJob.Title);
        }

        [TestMethod]        
        public async Task Skip_Omitted_Fields()
        {
            var dtoJob = new DtoJob { Title = "Empty" };
            await Job.MapAsync()
                .Optional((int nonExistingField) => dtoJob.Title);

            Assert.AreEqual("Empty", dtoJob.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingFieldException))]
        public async Task Throw_On_Missing_Required_Field()
        {
            var dtoJob = new DtoJob { Title = "Empty" };
            await Job.MapAsync()
                .Required((string nonExistingField) => dtoJob.Title);
        }

        [TestMethod]
        public async Task Assert_Required_Value()
        {
            var dtoJob = new DtoJob { Id = 123 };
            await Job.MapAsync()
                .RequiredAssert((int id) => dtoJob.Id == id);
        }

        [TestMethod]
        public async Task Assert_Optional_Value()
        {
            var dtoJob = new DtoJob { Id = 123 };
            await Job.MapAsync()
                .OptionalAssert((int id) => dtoJob.Id == id);
        }

        [TestMethod]
        [ExpectedException(typeof(ValueMistmatchException))]
        public async Task Throw_On_RequiredAssert_Mistmatch()
        {
            var dtoJob = new DtoJob { Id = 33 };
            await Job.MapAsync()
                .RequiredAssert((int id) => dtoJob.Id == id);
        }

        [TestMethod]
        public async Task Skip_OptionalAssert_For_Omitted_Field()
        {
            var dtoJob = new DtoJob();
            await Job.MapAsync()
                .OptionalAssert((int nonExistingField) => dtoJob.Id == nonExistingField);
        }
    }
}
