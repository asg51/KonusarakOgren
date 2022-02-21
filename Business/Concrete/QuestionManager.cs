using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private IQuestionDal questionDal;
        public QuestionManager(IQuestionDal questionDal)
        {
            this.questionDal = questionDal;
        }
        public void Add(Question question)
        {
            this.questionDal.Add(question);
        }

        public void AddRange(IList<Question> questions)
        {
            this.questionDal.AddRange(questions);
        }

        public void Delete(Question question)
        {
            this.questionDal.Delete(question);
        }

        public void DeleteRange(IList<Question> questions)
        {
            this.questionDal.DeleteRange(questions);
        }

        public List<Question> GetAll(Expression<Func<Question, bool>> filter = null)
        {
            return this.questionDal.GetAll(filter);
        }

        public bool QuestionCheck(ResultQuizRequest resultQuizRequest)
        {
            return this.questionDal.Get(x => x.Id == int.Parse(resultQuizRequest.Id)).TheRightOption == resultQuizRequest.Value;
        }
    }
}
