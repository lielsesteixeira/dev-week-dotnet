using System.Collections.Generic;

namespace src.Models;
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Doc { get; set; }
    public bool Active { get; set; }
    public List<Contract> Contracts { get; set; }
    
    public Person()
    {
        this.Id = 1;
        this.Name = "John Doe";
        this.Doc = "0000000";
        this.Contracts = new List<Contract>();
        this.Active = true;
    }

    public Person(
        string Name, 
        string Cpf
        )
    {
        this.Name = Name;
        this.Doc = Cpf;
        this.Contracts = new List<Contract>();
        this.Active = true;
    }
}