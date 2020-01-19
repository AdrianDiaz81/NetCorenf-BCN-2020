namespace NetCoreConf.BCN.API.API.OData
{

    using System.Collections.Generic;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Routing;
    using Microsoft.AspNetCore.Mvc;
    using NetCoreConf.BCN.API.Model;

    [ODataRoutePrefix("Person")]
    public class PersonController : ODataController
    {
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Avenger> Get()
        {
            return new List<Avenger>
            {
                CreateNewAvenger("1","Cody Allen","", "130"),
                CreateNewAvenger("2","Todd Ostermeier","", "160"),
                CreateNewAvenger("3","Viral Pandya","", "140")
            };
        }

        private static Avenger CreateNewAvenger(string id, string name, string description, string url)
        {
            return new Avenger
            {
                Id = id,
                Name = name,
                Description = description,
                UrlPhoto = url
            };
        }
    }
}