using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

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
        public void Copy_Scalar()
        {            
            var dtoJob = new DtoJob { Title = "Empty" };
            Job.Optional((string title) => dtoJob.Title);
            Assert.AreEqual("tester", dtoJob.Title);            
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Throw_On_Type_Mistmatch()
        {
            var dtoJob = new DtoJob { Title = "Empty" };
            Job.Optional((int title) => dtoJob.Title);
        }

        [TestMethod]        
        public void Skip_If_No_Data()
        {
            var dtoJob = new DtoJob { Title = "Empty" };
            Job.Optional((int nonExistingField) => dtoJob.Title);
            Assert.AreEqual("Empty", dtoJob.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingFieldException))]
        public void Throw_On_Missing_Required_Field()
        {
            var dtoJob = new DtoJob { Title = "Empty" };
            Job.Required((string nonExistingField) => dtoJob.Title);
        }

        [TestMethod]
        public void Copy_Array()
        {
            var dtoJob = new DtoJob { Types = new[] { "Remote" } };
            Job.Optional((string[] types) => dtoJob.Types);
            CollectionAssert.AreEqual(new[] { "Full-Time", "Part-Time" }, dtoJob.Types.ToList());            
        }
    }
}
