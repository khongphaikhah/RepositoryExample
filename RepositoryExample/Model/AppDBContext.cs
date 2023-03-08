using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RepositoryExample.Model
{
    public class AppDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public string ConnectionString { get; private set; }
        public AppDBContext()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ConnectionString = Path.Combine(folder, "repo.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source= {ConnectionString}");
        }
    }

    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }

    public class Category : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }

    public class Customer : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string Address { get; set; }
    }
}
