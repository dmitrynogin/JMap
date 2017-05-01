# JMap

This library helps merging partial WEB API JSON payload with existing prepopulated DTO objects. 

Let's say that JSON is represented by JObject from JSON.NET package. Naïve implementation will probably get us to the following code for the optional string property mapping:

    var jToken = jObject["optionalScalar"];
    if(jToken!= null)
         dto.OptionalScalar = jToken.Value<string>();

where required mapping would need throw an exception:

    var jToken = jObject["requiredScalar "];
    if(jToken!= null)
         dto.RequiredScalar = jToken.Value<string>();
    else
         throw new MissingFieldException("requiredScalar");

Collection mapping is a way more verbose, as we need to instantiate/find necessary DTO for collection items and perform the same logic as above on their individual properties. 

`JMap` library allows to define this mapping declaratively and execute necessary requests to external data sources concurrently.

Given the following example JSON:

    {
      "id": 123,
      "title": "tester",
      "company": {
          "name": "Microsoft",
          "size": 50000,
          "industries": [
             { "id": 1 },
             { "id": 2 }
          ]
       },
       "types": [ "Full-Time", "Part-Time" ],
       "locations": [
          {
             "city": "Vancouver",
             "country": "Canada"
          }
       ]
    }

We could map it to the following DTO structure:

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
         ...
    }

Using the following declaration:

            await job.MapAsync()
                .RequiredAssert((int id) => id == dtoJob.Id)
                .Optional((string title) => dtoJob.Title)
                .Optional((JObject company) => dtoJob.Company, (company, dtoCompany) => company
                    .Optional((string name) => dtoCompany.Name)
                    .Optional((int size) => dtoCompany.Size)
                    .Optional((JObject[] industries) => dtoCompany.Industries, industry => 
                        IndustryReader.ReadIndustryAsync(industry.Id())))
                .Optional((string[] types) => dtoJob.Types)
                .Optional((JObject[] locations) => dtoJob.Locations, (location, dtoLocation) => location
                    .Required((string city) => dtoLocation.City)
                    .Required((string country) => dtoLocation.Country));

Where lines like this:

    .RequiredAssert((int id) => id == dtoJob.Id)

Represents a necessary condition to check, while

    .Optional((string title) => dtoJob.Title)

Defines an automatic coercion between string in JSON to the data type of the `dtoJob.Title` property, while

    .Optional((JObject[] industries) => dtoCompany.Industries, industry => 
        IndustryReader.ReadIndustryAsync(industry.Id())))

Defines a conversion from `JObject` array to collection of some DTO objects loaded concurrently from the database and assigned to the `dtoCompany.Industries` property, while

     .Optional((JObject company) => dtoJob.Company, (company, dtoCompany) => company
         .Optional((string name) => dtoCompany.Name)
         .Optional((int size) => dtoCompany.Size)
         .Optional((JObject[] industries) => dtoCompany.Industries, industry => 
             IndustryReader.ReadIndustryAsync(industry.Id())))

Defines a merge of JObject `company` field content to `dtoJob.Company` object, creating one if missing.

As shown, there are the following permutations of mapping declarations:

* Optional/Required   
* Coercion/Conversion/Merge 
* JSON type for pattern matching could be:
  - a string, int, long, float, doable, bool, DateTime;
  - their nullable counterparts;
  - JObject;
  - An array of above.

