using InfotechLab.Business.Services.Abstract;
using InfotechLab.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfotechLab.Business.Services.Concrete
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        private readonly IEfEntityRepositoryBase<TEntity> _repository;

        public BaseService(IEfEntityRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
