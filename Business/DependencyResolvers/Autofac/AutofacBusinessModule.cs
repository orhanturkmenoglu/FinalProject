using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule : Module
    {
        // Autofac teknolojisi bize bağımlılıklarımızı çözmemizi sağlayacak
        // Load() : uygulama yayına geçtiği zaman çalışacak kısım
        // SingleInstance() : tek bir instance oluşssun. herkes onu kullansın 
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
