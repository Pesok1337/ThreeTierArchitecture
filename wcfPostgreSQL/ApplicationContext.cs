using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wcfPostgreSQL
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null;
        public DbSet<Company> Company { get; set; } = null;
        public DbSet<Country> Country { get; set; } = null;
        public ApplicationContext() 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; port=5432; Database=testdb; UserName=postgres; Password=admin");
            //base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Country rus = new Country();
            rus.Id = 1;

            Company roga = new Company("Рэу", 2);

            Customer pupkin = new Customer(3, "Маныч", roga.Id);
            Customer ivanov = new Customer(4, "Рамазанов", roga.Id);

            modelBuilder.Entity<Country>().HasData(rus);
            modelBuilder.Entity<Company>().HasData(roga);
            modelBuilder.Entity<Customer>().HasData(pupkin, ivanov);
            //base.OnModelCreating(modelBuilder);
        }
        public void CountryConfigure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries").Property(i => i.Id).HasDefaultValue(1);
            builder.ToTable("Country").HasIndex(c => c.Name).IsUnique();
            builder.ToTable("Country").Property(c => c.Name).HasDefaultValue("Россия");
        }
    }
    [Table("customers")]
    public class Customer
    {
        [Column("cust_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("cust_name")]
        public string Name { get; set; }
        [Column("company_id")]
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public Customer(string name) { Name = name; }
        public Customer(string name, int companyid) { Name = name; CompanyId = companyid;}
        public Customer(int id, string name, int companyid) { Id= id; Name = name;CompanyId = companyid;}
    }
    [Table("companies")]
    public class Company
    {
        [Column("comp_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("comp_name")]
        public string Name { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public Company(string name) { Name = name; }
        public Company(string name, int id) { Name = name; Id = id;}
    }

    [Table("countries")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("coun_id")]
        public int Id { get; set; }
        [Column("coun_name")]
        public string Name { get; set; }
    }
}
