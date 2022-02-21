using Business.Abstract;
using Entities.Dtos;
using Entities.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Controllers
{
    public class TakeAnQuizController : Controller
    {
        private IQuizService quizService;
        private IQuestionService questionService;
        public TakeAnQuizController(IQuizService quizService, IQuestionService questionService)
        {
            this.quizService = quizService;
            this.questionService = questionService;
        }
        public IActionResult Take(int id)
        {
            TakeQuizDto takeQuizDto = quizService.GetTakeQuiz(id);
            return View(takeQuizDto);
        }
        [HttpPost]
        public JsonResult Result(string data)
        {
            ResultQuizRequest resultQuizRequest = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultQuizRequest>(data);
            bool result = questionService.QuestionCheck(resultQuizRequest);
            return new JsonResult(result.ToString());
        }
    }
}
