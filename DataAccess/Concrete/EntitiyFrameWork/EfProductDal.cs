using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfProductDal : IProductDal
    {
        public EntityState EntityState { get; private set; }

        public void Add(Product entity)
        {
            //IDısposable pattern implementation of c#
            using (NorthWindContext context = new NorthWindContext())
            {
               var addedEntity = context.Entry(entity); //referansı yakala 
                addedEntity.State = EntityState.Added; //ampulden düzelt // o aslında eklenecek bir nesne
                context.SaveChanges(); // ve şimdi ekle
            }
            //using fonksiyonu bittiği anda belleği temizler
        }
       
        public void Delete(Product entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var deletedEntity = context.Entry(entity);  
                deletedEntity.State = EntityState.Deleted; 
                context.SaveChanges(); 
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter) //bir filtre verdik
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); //bu kod standarttır sadece product yerine category, customer diye değişir
                //standart gördüğümzü yerde onu generic base yaparız ---- ileriki derslerde      
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null) // ancak null oldugu için burada filtre vermese olur (hata olmaz)    
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();  //Eğer filtre null ise ilk kısım, değilse ikinci kısım calısır 
            // producta yerleş ve oradaki tüm datayı listeye ekle demek 
            //arka planda Select * from product döndürür ve listeye cevirir 
             }
        }

        public void Update(Product entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
