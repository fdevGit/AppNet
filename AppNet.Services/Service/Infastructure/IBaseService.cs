using AppNet.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AppNet.Services.Service.Infastructure
{
    public interface IBaseService<T> where T : BaseViewModel
    {
        T Create(T model);
        bool Update(T model);
        bool Delete(T model);
        bool Update(int id);
        bool Delete(int id);

        T Get(int id);
        List<T> GetAll(Expression<Func<T, bool>> expression = null);

    }
}
