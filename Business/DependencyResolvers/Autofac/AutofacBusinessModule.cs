using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<QuizManager>().As<IQuizService>().SingleInstance();
            builder.RegisterType<QuizDal>().As<IQuizDal>().SingleInstance();

            builder.RegisterType<QuestionManager>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<QuestionDal>().As<IQuestionDal>().SingleInstance();

            builder.RegisterType<AdminManager>().As<IAdminService>().SingleInstance();
            builder.RegisterType<AdminDal>().As<IAdminDal>().SingleInstance();



            //autofac yaptımız bütün classların attribute çalıştırmaya yarar 
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
