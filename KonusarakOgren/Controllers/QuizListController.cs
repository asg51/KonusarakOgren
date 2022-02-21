using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Controllers
{
    public class QuizListController : Controller
    {
        private IQuizService quizService;
        public QuizListController(IQuizService quizService)
        {
            this.quizService = quizService;
        }
        public IActionResult List()
        {
            var result = quizService.GetAllQuizInformation();
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            this.quizService.Delete(id);
            return RedirectToAction("List", "QuizList");
        }
    }
}
