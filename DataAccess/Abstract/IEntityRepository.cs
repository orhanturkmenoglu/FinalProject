using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // Expression<Func<T,bool>> filter=null : bu kullandığımız expression linq ile birlikte geliyoru 
    // biz  bu yapıyla hangi ürünü istiyorsak onu getirmemizi saglar. null filtre vermeyedebiliriz demek 
    // filtre vermezsek butun datayı getirir

    // Expression<Func<T, bool>> filter : filtre vermek zorunlu o urunun detayına gitmek için kullanıl

    // Crud operasyonlar:add,delete,update

    // Generic constraint: kısıtlama yapmamızı saglar (where T: class,IEntity,new()) 
    // class: T için referans tutan olmalı,
    // IEntity:IEntity olabilir veya IEntityden  implement olan  olmalı 
    //new(): newlenebilir olması gerek.
    public interface IEntityRepository<T> where T: class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        
    }
}
