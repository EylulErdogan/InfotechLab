using InfotechLab.Core;
using InfotechLab.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Data.Abstract;
using InfotechLab.Entities;

namespace InfotechLab.Data.Concrete
{
    public class EfEntityRepositoryBase<TEntity> : IEfEntityRepositoryBase<TEntity> where TEntity : class
    {
        readonly InfotechLabContext _context;
        readonly DbSet<TEntity> _dbSet;
        public EfEntityRepositoryBase(InfotechLabContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public bool Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
			if (filter == null)
			{
				return _dbSet.FirstOrDefault();
			}
			else
			{
				return _dbSet.Where(filter).FirstOrDefault();
			}
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return _dbSet.ToList();
            }
            else
            {
                return _dbSet.Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
			return entity;
        }
        public InfotechLabContext GetContext()
        {
            return _context;
        }
    }
}
