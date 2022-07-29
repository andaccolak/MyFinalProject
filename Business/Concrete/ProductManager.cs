using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _ProductDal;

        public ProductManager(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları 
            //yetkisi var mı  bu sorgulamaları gecerse asagıdaki calısır
            return _ProductDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _ProductDal.GetAll(p => p.CategoryId == id);
        }

       public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);// bunu yazdıktan sonra konsola gidip bu kodu cagırıp parantez
                                                                                     //içine istedğimiz filtreyi yazarız 

            //ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach (var product in productManager.GetAllByCategoryId(2))
            //{
            //    Console.WriteLine(product.UnitPrice);
            //}        -------- gibi 


            //veya 


            //ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach (var product in productManager.GetByUnitPrice(50, 100))
            //{
            //    Console.WriteLine(product.ProductName);
            //}    -------- gibi

        }
    }
}
