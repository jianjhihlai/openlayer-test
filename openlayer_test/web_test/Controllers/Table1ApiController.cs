using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Openlayer_test.TESTDB;
using Openlayer_test.TESTDB.Interface;
using Openlayer_test.TESTDB.EF;

namespace web_test.Controllers
{
    public class Table1ApiController : ApiController
    {

        private ITable1Repository _db = new Table1Repository();
        // GET api/<controller>
        public IEnumerable<Openlayer_test.TESTDB.Table1> Get()
        {
            var table1 = _db.GetAll();
            return table1.ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}