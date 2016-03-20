using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuery.Tests
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
                .Try((string title) => dtoJob.Title)
                .Try((JObject company) => dtoJob.Company, (company, dtoCompany) => company
                    .Try((string name) => dtoCompany.Name)
                    .Try((int size) => dtoCompany.Size)
                    .Try((JObject[] industries) => dtoCompany.Industries, industry => 
                        IndustryReader.ReadIndustry(industry.Id())))
                .Try((string[] types) => dtoJob.Types)
                .Try((JObject[] locations) => dtoJob.Locations, (location, dtoLocation) => location
                    .Require((string city) => dtoLocation.City)
                    .Require((string country) => dtoLocation.Country));
        }
    }
}
