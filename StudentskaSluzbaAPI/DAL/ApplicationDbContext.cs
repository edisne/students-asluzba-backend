using Microsoft.EntityFrameworkCore;
using StudentskaSluzbaAPI.Models;
using StudentskaSluzbaAPI.Entities;

namespace StudentskaSluzbaAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){  }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDTO> StudentDTO { get; set; }
        public DbSet<StatusStudenta> StatusStudenta { get; set; }
        public DbSet<Korisnik>? Korisnik { get; set; }
    }
}
