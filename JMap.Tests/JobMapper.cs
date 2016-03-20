using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMap.Tests
{
    class JobMapper
    {
        public JobMapper(IIndustryReader industryReader)
        {
            IndustryReader = industryReader;
        }

        IIndustryReader IndustryReader { get; }

        public void Copy(JObject job, DtoJob dtoJob)
        {            
            job
                .RequiredAssert((int id) => id == dtoJob.Id)
                .Optional((string title) => dtoJob.Title)
                .Optional((JObject company) => dtoJob.Company, (company, dtoCompany) => company
                    .Optional((string name) => dtoCompany.Name)
                    .Optional((int size) => dtoCompany.Size)
                    .Optional((JObject[] industries) => dtoCompany.Industries, industry => 
                        IndustryReader.ReadIndustry(industry.Id())))
                .Optional((string[] types) => dtoJob.Types)
                .Optional((JObject[] locations) => dtoJob.Locations, (location, dtoLocation) => location
                    .Required((string city) => dtoLocation.City)
                    .Required((string country) => dtoLocation.Country));
        }
    }
}
