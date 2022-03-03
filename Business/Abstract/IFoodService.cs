using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFoodService
    {
        IDataResult<Food> GetById(int foodId);
        IDataResult<Food> GetFoodByUser(int userId);
        IDataResult<List<Food>> GetListByUser(int userId);
        IDataResult<List<Food>> GetList();

        IResult Add(Food food);
        IResult Delete(Food food);
        IResult Update(Food food);
    }
}
