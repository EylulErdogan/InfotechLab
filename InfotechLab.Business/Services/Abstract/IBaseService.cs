﻿using InfotechLab.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfotechLab.Business.Services.Abstract
{
    public interface IBaseService<TEntity>
    {
        TEntity Add(TEntity entity);
        bool Delete(TEntity entity);
        //Expression sorgu  oluşturmamızı sağlar Func ise bu sorgunun hangi tablo nesnesi üzerinde kullanacağını belirtmemizi sağlar 
        TEntity Get(Expression<Func<TEntity, bool>> filter);


        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Update(TEntity entity);

        bool Any(Expression<Func<TEntity, bool>> filter);
    }
}
