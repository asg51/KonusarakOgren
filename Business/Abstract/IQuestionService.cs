using Entities.Concrete;
using Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionService
    {
        void Add(Question question);
        void AddRange(IList<Question> questions);
        void Delete(Question question);
        void DeleteRange(IList<Question> questions);
        List<Question> GetAll(Expression<Func<Question, bool>> filter = null);
        public bool QuestionCheck(ResultQuizRequest resultQuizRequest);
    }
}
