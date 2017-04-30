using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMap.Tests
{
    public class DtoJob
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DtoCompany Company { get; set; }
        public IList<string> Types { get; set; }
        public IList<DtoLocation> Locations { get; set; }
    }

    public class DtoCompany
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public IList<DtoIndustry> Industries { get; set; }
    }

    public class DtoLocation
    {
        public string City { get; set; }
        public string Country { get; set; }
    }

    public interface IIndustryReader
    {
        DtoIndustry ReadIndustry(int id);
        Task<DtoIndustry> ReadIndustryAsync(int id);
    }

    public class DtoIndustry
    {

    }
}
