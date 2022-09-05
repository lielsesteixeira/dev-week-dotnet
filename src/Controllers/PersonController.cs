using Microsoft.AspNetCore.Mvc;

using src.Models;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    
    [HttpGet]
    public Person Get(){

        Person person = new Person(
            "John Doe",
            "0000000"
        );
        
        Contract newContract = new Contract(
            "000000", 0.00
            );        
        
        person.Contracts.Add(newContract);

        return person;
    }

    [HttpPost]
    public Person Post(
        [FromBody]Person person
    ){
        return person;
    }

    [HttpPut("{id}")]
    public string Update(
        [FromRoute]int id,
        [FromBody]Person person
    ){
        return " Id: " + id + "updated";
    }

    [HttpDelete]
    public string Delete(
        [FromRoute]int id
    ){
        return "deleted person with id " + id;
    }
}