using Business.Abstract;
using Entities.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.Controllers
{
    public class QuizCreationController : Controller
    {
        private IQuizService quizService;
        public QuizCreationController(IQuizService quizService)
        {
            this.quizService = quizService;
        }
        [HttpGet]
        public IActionResult CreateQuiz()
        {
            WebClient webClient = new WebClient();
            var html = webClient.DownloadString("https://www.wired.com/");
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);
            List<SelectListItem> listItems = new List<SelectListItem>();
            for (int i = 1; i < 6; i++)
            {
                var secilenHtml = $"/html/body/div[1]/div/main/div[1]/div[1]/section/div[3]/div/div/div/div/div[{i}]/div[2]/a";

                var secilenHtmlList = htmlDocument.DocumentNode.SelectNodes(secilenHtml);
                string href = secilenHtmlList[0].Attributes.FirstOrDefault(x => x.Name == "href").Value;
                string text = secilenHtmlList[0].SelectNodes("h2")[0].InnerText;

                listItems.Add(new SelectListItem(text, href));
            }
            ViewBag.listItems = listItems;
            ViewBag.paragraph = getParagraph(listItems[0].Value);

            return View();
        }


        [HttpPost]
        public IActionResult CreateQuiz(CreateQuizRequest quizRequest)
        {
            this.quizService.Add(quizRequest);
            return RedirectToAction("List", "QuizList");
        }

        public JsonResult List(string value)
        {
            string result = getParagraph(value);

            //
            return Json(new { text = result });
        }

        private string getParagraph(string value)
        {
            WebClient webClient = new WebClient();
            string result = "";
            var html = webClient.DownloadString("https://www.wired.com" + value);
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);
            for (int i = 1; i < 6; i++)
            {
                var secilenHtml = $"/html/body/div[1]/div/main/article/div[2]/div[1]";
                var secilenHtmlList = htmlDocument.DocumentNode.SelectNodes(secilenHtml);
                var htmlNodes = FirstOfClassAttribute(secilenHtmlList, "GridWrapper-vNBSO");

                foreach (var item in htmlNodes)
                {
                    result += item.InnerText + " ";
                }
            }

            return result;
        }

        private HtmlAgilityPack.HtmlNodeCollection FirstOfClassAttribute(HtmlAgilityPack.HtmlNodeCollection htmlNodes, string classValue)
        {//"GridWrapper - vNBSO"
            foreach (var item in htmlNodes)
            {
                if (item.Attributes.FirstOrDefault(x => x.Value.Contains(classValue)) != null)
                {
                    return item.ChildNodes;
                }
                else
                {
                    return FirstOfClassAttribute(item.ChildNodes, classValue);
                }
            }
            return null;
        }
    }
}
