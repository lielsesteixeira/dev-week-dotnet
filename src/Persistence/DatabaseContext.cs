
using Microsoft.EntityFrameworkCore;

using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext
    (
        DbContextOptions<DatabaseContext> options
    ) : base(options)
    {}

    public DbSet<Person> Persons { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    
    protected void onModelCreating(
        ModelBuilder builder){
            builder.Entity<Person>( table => {
                table.HasKey( e => e.Id);
                table
                    .HasMany(e => e.Contracts)
                    .WithOne()
                    .HasForeignKey(c => c.PersonId);
            });
            builder.Entity<Contract>( table => {
                table.HasKey(e => e.DocId);
            });
        }
}