using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class QuizDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
    }
}
