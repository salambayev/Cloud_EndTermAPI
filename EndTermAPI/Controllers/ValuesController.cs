using EndTermAPI.DAL;
using EndTermAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EndTermAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private PersonContext pc = new PersonContext();
        // GET api/values
        public IEnumerable<Person> Get()
        {
            List<Person> tempPerson = pc.Persons.ToList();
            return tempPerson;
        }

        // GET api/values/5
        public string Get(int id)
        {
            List<Person> tempPerson = pc.Persons.ToList();
            Person ans = tempPerson.FirstOrDefault((p) => p.ID == id);
            return ans.ToString();
        }

        // POST api/values
        public void Post([FromBody]Person value)
        {
            pc.Persons.Add(value);
            pc.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            string[] temp = value.Split(' ');
            Person person = pc.Persons.FirstOrDefault((d) => d.ID == id);
            pc.Persons.Remove(person);
            Person p = new Person();
            p.Name = temp[0];
            p.Date = DateTime.Parse(temp[1]);
            p.Telephone = temp[2];
            pc.Persons.Add(p);
            pc.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Person person = pc.Persons.FirstOrDefault((p) => p.ID == id);
            pc.Persons.Remove(person);
            pc.SaveChanges();
        }
    }
}
