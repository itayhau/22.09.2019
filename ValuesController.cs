using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication3.Controllers
{
    [BasicAuthentication]
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            //return Ok(new[] { "1", "2", RequestContext.Principal.Identity.ToString() });
            //var x = RequestContext.Principal.Identity.ToString();

            return Ok(new[] { "1", "2", Thread.CurrentPrincipal.Identity.Name });
            
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
