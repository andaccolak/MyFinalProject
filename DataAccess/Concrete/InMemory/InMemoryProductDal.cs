using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>() {
                new Product() { CategoryId = 1, ProductId = 1, ProductName = "bardak", UnitPrice = 15, UnitsInStock = 15 },
                new Product() { CategoryId = 2, ProductId = 2, ProductName = "kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product() { CategoryId = 3, ProductId = 2, ProductName = "telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product() { CategoryId = 4, ProductId = 2, ProductName = "klavye", UnitPrice = 150, UnitsInStock = 65 },
                new Product() { CategoryId = 5, ProductId = 2, ProductName = "fare", UnitPrice = 85, UnitsInStock = 1 }



            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //bu kod listedeki tüm elemanları dolasır ve dolastıgı her elemana
            //verdiğimiz takma isim p'dir (foreach gibi görev görür ve parantez içindeki eşit olanı bulur)
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün ID'sine sahip olan listedeki ürünü bul
            Product productUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productUpdate.ProductName=product.ProductName;
            productUpdate.CategoryId = product.CategoryId;
            productUpdate.UnitPrice = product.UnitPrice;
            productUpdate.UnitsInStock = product.UnitsInStock;

            List<Product> GetAllByCategory(int CategoryId)
            {
                return _products.Where(p => p.CategoryId == CategoryId).ToList();
            }
        }
    }
}
