using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using src.Models;
using src.Persistence;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    //_context is repository
    private DatabaseContext _context { get; set; }
    
    public PersonController(DatabaseContext context){
        this._context = context;
    } 

    [HttpGet]
    public List<Person> Get(){
        return _context.Persons
        .Include(p => p.Contracts)
        .ToList(); 
    }

    [HttpPost]
    public Person Post(
        [FromBody]Person person
    ){
        _context.Persons.Add(person);
        _context.SaveChanges();

        return person;
    }

    [HttpPut("{id}")]
    public string Update(
        [FromRoute]int id,
        [FromBody]Person person
    ){
             var result = _context
                    .Persons
                    .SingleOrDefault(e => e.Id == id);

            _context.Persons.Update(result);
            _context.SaveChanges();

        return " Id: " + id + " updated";
    }

    [HttpDelete("{id}")]
    public string Delete(
        [FromRoute]int id
    ){
    
      var result = _context
                    .Persons
                    .SingleOrDefault(e => e.Id == id);

            _context.Persons.Remove(result);
            _context.SaveChanges();

        return "deleted person with id " + id;
    }
}