using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id); //bunu en son ekledik

        List<Product> GetByUnitPrice(decimal min, decimal max); // yeni liste eklemek istersek buraya gelicez sonra da managere gidicez
    }
}
