using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FoodManager : IFoodService
    {
        private IFoodDal _foodDal;

        public FoodManager(IFoodDal foodDal)
        {
            _foodDal = foodDal;
        }

        public IResult Add(Food food)
        {
            _foodDal.Add(food);
            return new SuccessResult(Messages.FoodAdded);
        }

        public IResult Delete(Food food)
        {
            _foodDal.Delete(food);
            return new SuccessResult(Messages.FoodDeleted);
        }

        public IDataResult<Food> GetById(int foodId)
        {
            return new SuccessDataResult<Food>(_foodDal.Get(f => f.Id == foodId));
        }

        public IDataResult<Food> GetFoodByUser(int userId)
        {
            return new SuccessDataResult<Food>(_foodDal.Get(f => f.UserId == userId));
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Food>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Food>>(_foodDal.GetList().ToList());
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Food>> GetListByUser(int userId)
        {
            return new SuccessDataResult<List<Food>>(_foodDal.GetList(f => f.UserId == userId).ToList());
        }

        public IResult Update(Food food)
        {
            _foodDal.Update(food);
            return new SuccessResult(Messages.FoodUpdated);
        }
    }
}
