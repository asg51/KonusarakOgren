using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class TakeQuizDto
    {
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public TakeQuestionDto QuestionOne { get; set; }
        public TakeQuestionDto QuestionTwo { get; set; }
        public TakeQuestionDto QuestionThree { get; set; }
        public TakeQuestionDto QuestionFour { get; set; }
    }
}
