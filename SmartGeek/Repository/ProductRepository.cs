using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SmartGeek.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByBrandName(string brandName);
        IEnumerable<Product> GetProductsByBrandName(string brandName);
    }

    public class ProductRepository : Repository<Product>, IProductRepository, IDisposable
    {
        private readonly Context _context;

        public ProductRepository(Context context) : base(context)
        {
            _context = context;
        }

        public Product GetByBrandName(string brandName)
        {
            try
            {
                return _context.Products?
                    .Where(x => x.Brand.Name == brandName)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<Product> GetProductsByBrandName(string brandName)
        {
            try
            {
                return _context
                    .Products
                    .Where(x => x.Brand.Name == brandName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            _context.SaveChanges();
            _context?.Dispose();
        }
    }
}