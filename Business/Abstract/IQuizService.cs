using Entities.Concrete;
using Entities.Dtos;
using Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuizService
    {
        public void Add(CreateQuizRequest quizRequest);
        public void Delete(int id);
        public List<QuizDto> GetAllQuizInformation();
        public TakeQuizDto GetTakeQuiz(int id);
    }
}
