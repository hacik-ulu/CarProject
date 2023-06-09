﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1,ColorId=157463, ModelYear=2015, DailyPrice=300,Description ="Sedan Model" },
                new Car{CarId=2, BrandId=1,ColorId=741963, ModelYear=2020, DailyPrice=500,Description ="Sedan Model" },
                new Car{CarId=2, BrandId=2,ColorId=123789, ModelYear=2018, DailyPrice=420,Description ="SUV Model" },
                new Car{CarId=1, BrandId=2,ColorId=753159, ModelYear = 2019, DailyPrice=480,Description ="Cabrio Model" },
                new Car{CarId=2, BrandId=1,ColorId=357159, ModelYear = 2022, DailyPrice=1000,Description ="HB Model" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }


        public void Delete(Car car)
        {
            Car productToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(productToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c=>c.CarId == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetCarsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetColorsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car productToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            productToUpdate.CarId = car.CarId;
            productToUpdate.BrandId = car.BrandId;
            productToUpdate.ColorId = car.ColorId;
            productToUpdate.ModelYear = car.ModelYear;
            productToUpdate.DailyPrice = car.DailyPrice;
            productToUpdate.CarId = car.CarId;
            _cars.Add(productToUpdate);
        }

       
    }
}
