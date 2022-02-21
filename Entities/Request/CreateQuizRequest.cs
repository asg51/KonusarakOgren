using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Request
{
    public class CreateQuizRequest
    {
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public CreateQuestionInformation QuestionOne { get; set; }
        public CreateQuestionInformation QuestionTwo { get; set; }
        public CreateQuestionInformation QuestionThree { get; set; }
        public CreateQuestionInformation QuestionFour { get; set; }
    }

    public class CreateQuestionInformation
    {
        public string Paragraph { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public Option TheRightOption { get; set; }
    }

    public enum Option
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3
    }
}
