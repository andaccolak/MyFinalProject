using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic constraint ( generik kısıt ) T'nin neler olup neler olamayacagını kısıtlarız
    // class : referans tip
    //IEntity olabilir veya Ientity implemente eden bir nesne olabilir filtresi getiririz
    //new(); new'lenebilir olmalı         eğer bu filtreyi getirmezsek 
    // category,product,customer ve IEntitity sınıflarını filtrelerdik ancak
    //biz IEntity istemiyoruz ve new() filtresi getiriyoruz
    //IEntity interface oldugu için yenilenemez yani o da filtre dısında kaldı artık sadece classlar kaldı
    //category,product,customer kalır
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //liste olarak gelen tercihler
        T Get(Expression<Func<T, bool>> filter);  // ve o listeden bir tanesini çağırma 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
      //  List<T> GetAllByCategory(int entity); üstteki yazdıgımız yeşil ile buna ihtiyac kalmadı
       
    }
}
 