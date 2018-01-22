using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonApi.Models;

namespace PersonApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PersonController : Controller
    {

        private static List<Person> persons = new List<Person>();
        
        public PersonController(){
            persons.Add(new Person {Id = 1, FirstName = "Hans", LastName = "Lauritzen"});
            persons.Add(new Person {Id = 2, FirstName = "Grete", LastName = "Hansen"});
            persons.Add(new Person {Id = 3, FirstName = "Olga", LastName = "Spitz"});
        }

        [HttpGet]
        public IEnumerable<Person> Persons(){
            var personSerialize = JsonConvert.SerializeObject(persons);
            var personDeserialize = JsonConvert.DeserializeObject<List<Person>>(personSerialize);
            return personDeserialize;
        }

        //[HttpGet("{id:int}")]
        public IActionResult Person(int id) {
            var person = persons.Where(x => x.Id == id).FirstOrDefault();
            if (person == null){
                return NotFound($"Id = {id} does not exists");
            }
            return Ok(person);
        }
        
        //http://localhost:5000/api/person/addperson?id=4&firstname=per&lastname=berg
        [HttpPost]
        public IActionResult AddPerson([FromBody] Person p){
            persons.Add(p);
            return Ok(persons);
        }

        //http://localhost:5000/api/person/addperson?id=4&firstname=per&lastname=berg
        // [HttpGet]
        // public IActionResult AddPerson(Person p){
        //     persons.Add(p);
        //     return Ok(persons);
        // }

    }
}