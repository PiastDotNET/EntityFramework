using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGeek.Repository;

namespace SmartGeek.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly Context _context;

        public ValuesController()
        {
            _context = new Context();

            using (var productRepository = new ProductRepository(_context))
            {
                productRepository.Create(new Product()
                {
                    Name = "1000MX3",
                    Price = 1600,
                    Brand = new Brand()
                    {
                        Name = "Sony"
                    }
                });
            }

            IRepository<Attribute> attributeRepository = new Repository<Attribute>(_context);
            attributeRepository.GetById(122);
        }

        public Product Get(int id)
        {
            Product product = null;

            using (var productRepository = new ProductRepository(_context))
            {
                product = productRepository.GetById(id);
            }

            return product;
        }
    }
}
