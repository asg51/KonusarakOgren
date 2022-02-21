using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuizManager : IQuizService
    {
        private IQuizDal quizDal;
        private IQuestionService questionService;
        public QuizManager(IQuizDal quizDal, IQuestionService questionService)
        {
            this.quizDal = quizDal;
            this.questionService = questionService;
        }

        public void Add(CreateQuizRequest quizRequest)
        {
            // Quiz quiz = QuizMapper(quizRequest);
            Quiz quiz = Mapping<Quiz, CreateQuizRequest>(quizRequest);
            quiz.Questions = new List<Question>
            {
                Mapping<Question, CreateQuestionInformation>(quizRequest.QuestionOne),
                Mapping<Question, CreateQuestionInformation>(quizRequest.QuestionTwo),
                Mapping<Question, CreateQuestionInformation>(quizRequest.QuestionThree),
                Mapping<Question, CreateQuestionInformation>(quizRequest.QuestionFour)
            };

            quiz.DateTime = DateTime.Now;

            this.quizDal.Add(quiz);

            var quizId = this.quizDal.GetAll(x => x.Title == quiz.Title).Last().Id;

            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                quiz.Questions[i].QuizId = quizId;
            }

            this.questionService.AddRange(quiz.Questions);

        }

        public void Delete(int id)
        {
            Quiz quiz = this.quizDal.Get(x => x.Id == id);
            this.quizDal.Delete(quiz);

            List<Question> questions = this.questionService.GetAll(x => x.QuizId == quiz.Id);
            this.questionService.DeleteRange(questions);
        }

        public List<QuizDto> GetAllQuizInformation()
        {
            return this.quizDal.GetAll().Select(x => new QuizDto
            {
                Id = x.Id,
                Title = x.Title,
                DateTime = x.DateTime
            }).ToList();
        }

        public TakeQuizDto GetTakeQuiz(int id)
        {
            Quiz quiz = this.quizDal.Get(x => x.Id == id);

            List<Question> questions = this.questionService.GetAll(x => x.QuizId == id);

            TakeQuizDto takeQuizDto = Mapping<TakeQuizDto, Quiz>(quiz);

            takeQuizDto.QuestionOne = Mapping<TakeQuestionDto, Question>(questions[0]);
            takeQuizDto.QuestionTwo = Mapping<TakeQuestionDto, Question>(questions[1]);
            takeQuizDto.QuestionThree = Mapping<TakeQuestionDto, Question>(questions[2]);
            takeQuizDto.QuestionFour = Mapping<TakeQuestionDto, Question>(questions[3]);

            return takeQuizDto;
        }

        private TDestination Mapping<TDestination, TSource>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
                  cfg.CreateMap<TSource, TDestination>()
              );

            Mapper mapper = new Mapper(config);

            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
