using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //Business katmanı DataAccess ile Interface aracılığıyla iletişim kurar.
        ICarDal _carDal;

        public CarManager(ICarDal cardal)
        {
            _carDal = cardal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba eklendi:" + car.Description);
            }
            else
            {
                Console.WriteLine("Araç tanımı en az 2 karakter içermelidir ve günlük fiyatı 0'dan büyük olmalı.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //İş Kodları
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c=>c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
