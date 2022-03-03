using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetList();
        IDataResult<List<Comment>> GetCommentByUser(int userId);
        IDataResult<List<Comment>> GetCommentByFood(int foodId);

        IResult Add(Comment comment);
        IResult Delete(Comment comment);
        IResult Update(Comment comment);
    }
}
