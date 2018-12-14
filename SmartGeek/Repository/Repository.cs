using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SmartGeek.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Update(T product);
        void Create(T entity);
        void Delete(T entity);
        T GetById(int id);
        void Create(IEnumerable<T> product);
    }

    public class Repository<T> : IRepository<T> where T: Entity
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public void Create(IEnumerable<T> product)
        {
            try
            {
                _context.BulkInsert(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Create(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public T GetById(int id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(T product)
        {
            try
            {
                _context.Set<T>().AddOrUpdate(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}