using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {

        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Comment>> GetCommentByFood(int foodId)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetList(c => c.FoodId == foodId).ToList());
        }

        public IDataResult<List<Comment>> GetCommentByUser(int userId)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetList(c => c.UserId == userId).ToList());
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Comment>> GetList()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetList().ToList());
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }
    }
}
