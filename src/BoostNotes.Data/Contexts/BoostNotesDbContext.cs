using Microsoft.EntityFrameworkCore;

using BoostNotes.Domain.Entities;

namespace BoostNotes.Data.Contexts;

public class BoostNotesDbContext : DbContext
{
    public BoostNotesDbContext(DbContextOptions<BoostNotesDbContext> options)
        : base(options)
    { }

    public DbSet<Note> Notes { get; set;}
}
