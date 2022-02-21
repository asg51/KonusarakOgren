using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class QuestionDal : EfEntityRepositoryBase<Question, MyContext>, IQuestionDal
    {
        public void AddRange(IList<Question> questions)
        {
            using (MyContext context = new MyContext())
            {
                foreach (var question in questions)
                {
                    var addedEntity = context.Entry(question);
                    addedEntity.State = EntityState.Added;
                }
                context.SaveChanges();
            }
        }

        public void DeleteRange(IList<Question> questions)
        {
            using (MyContext context = new MyContext())
            {
                foreach (var question in questions)
                {
                    var addedEntity = context.Entry(question);
                    addedEntity.State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }
    }
}
