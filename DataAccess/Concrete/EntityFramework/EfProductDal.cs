using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // IDisposable pattern implementation olarak geçer 
    // using:using işlemi bittiği anda  bellekten atılacaktır. 
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); // Entry : referansını yakalar gelen verinin
                addedEntity.State = EntityState.Added;   // aslında eklenecek yer
                context.SaveChanges(); // eklenecek olan işlemi yap kaydet.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); // Entry : referansını yakalar gelen verinin
                deletedEntity.State = EntityState.Deleted;   // aslında silinecek yer
                context.SaveChanges(); // eklenecek olan işlemi yap kaydet.
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); // Entry : referansını yakalar gelen verinin
                updatedEntity.State = EntityState.Modified;   // aslında güncellenecek yer
                context.SaveChanges(); // eklenecek olan işlemi yap kaydet.
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                return context.Set<Product>().SingleOrDefault(filter); // tek data getirecek
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : // null değilse filtrelenen kısmı getirecek
                    context.Set<Product>().Where(filter).ToList();
            }
        }

       
    }
}
