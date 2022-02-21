using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Quiz:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public DateTime DateTime { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}
