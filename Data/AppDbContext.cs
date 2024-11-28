using Microsoft.EntityFrameworkCore;
using Notes.Models;

namespace Notes.Data
{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Note> Notes { get; set; } = null!;
    }
}