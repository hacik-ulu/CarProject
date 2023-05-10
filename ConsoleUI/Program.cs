using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Araç Eklemesi

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(
               new Car
               {
                   BrandId = 1,
                   ColorId = 1,
                   ModelYear = 2022,
                   DailyPrice = 2000,
                   Description = "Tesla"
               }
                );

            //Araç silinmesi

            foreach (var car in carManager.GetAll().Where(c => c.BrandId == 17).ToList())
            {
                carManager.Delete(car);
                Console.WriteLine("Araç silindi:" + car.Description);
            }

            //Araç Güncelemesi

            foreach (var car in carManager.GetAll().Where(c => c.BrandId == 3).ToList())
            {
                car.Description = "Toyota Supra";
                carManager.Update(car);
                Console.WriteLine("Araç Güncellendi:" + car.Description);
            }


        }


    }
}
