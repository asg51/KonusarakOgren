using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Paragraph { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public int TheRightOption { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
