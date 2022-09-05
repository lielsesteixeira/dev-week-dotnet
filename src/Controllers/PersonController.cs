using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
    public ActionResult<List<Person>> Get(){
        
        var result = _context.Persons
                    .Include(p => p.Contracts)
                    .ToList(); 
        
        if(!result.Any()) return NoContent();

        return Ok(); 
    }

    [HttpPost]
    public ActionResult<Person> Post(
        [FromBody]Person person
    ){
        try
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
       
            return Created("Criado", person);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> Update(
        [FromRoute]int id,
        [FromBody]Person person
    ){
    
        var result = _context
                    .Persons
                    .SingleOrDefault(e => e.Id == id);

        if(result is null) return NotFound();

        try
        {
            _context.Persons.Update(result);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest( new {
                msg = $"Houve um erro ao tentar atualizar o id {id}",
                status = HttpStatusCode.OK
            });
        }   
            return Ok( new {
                msg = $"Dados do id {id} atualizados",
                status = HttpStatusCode.OK
        });
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete(
        [FromRoute]int id
    ){
    
        var result = _context
                    .Persons
                    .SingleOrDefault(e => e.Id == id);

        if(result is null){
            return BadRequest(new{
                msg="Conteúdo inexistente",
                status= HttpStatusCode.BadRequest
            });
        }
            _context.Persons.Remove(result);
            _context.SaveChanges();

            return Ok(new {
                msg= $"deleted person with id {id}",
                status= HttpStatusCode.OK
        });
    }
}