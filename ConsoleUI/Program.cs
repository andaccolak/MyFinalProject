﻿using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using System;
namespace ConsoleIU
{
    //SOLID 
    // OPEN CLOSED PRİNCİPLE (kodumuza yeni bilr klasör ekliyorsak diğer kodlara dokunamayız
    class program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(50,100))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}