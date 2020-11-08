using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.GenericRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly HREntities _context;
        public Repository(HREntities context)
        {
            _context = context;
        }

        public virtual TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public virtual TEntity Add(TEntity entiy)
        {
            try
            {
                entiy = _context.Set<TEntity>().Add(entiy);

                var r = _context.SaveChanges();

                return entiy;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        public virtual int AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            var result = _context.SaveChanges();

            return result;
        }

        public int Update(TEntity entiy)
        {
            try
            {
                _context.Set<TEntity>().Attach(entiy);
                _context.Entry<TEntity>(entiy).State = System.Data.Entity.EntityState.Modified;

                //_context.Entry(entiy).State = EntityState.Modified;
                var result = _context.SaveChanges();

                return result;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }


        public virtual int Remove(TEntity entiy)
        {
            _context.Set<TEntity>().Remove(entiy);
            var result = _context.SaveChanges();

            return result;
        }

        public virtual int RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            var result = _context.SaveChanges();

            return result;
        }

    }

}
