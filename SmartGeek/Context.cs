using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartGeek
{
    using System.Data.Entity;

    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
    }


    public class Product : Entity
    {
        public Product()
        {
            Attributes = new HashSet<Attribute>();    
        }

        public string Name { get; set; }
        public float Price { get; set; }
        public HashSet<Attribute> Attributes { get; set; }
        public Brand Brand { get; set; }
    }

    public class Attribute : Entity
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Brand : Entity
    {
        public string Name { get; set; }
    }

    public class Entity
    {
        public int Id { get; set; }
    }
}