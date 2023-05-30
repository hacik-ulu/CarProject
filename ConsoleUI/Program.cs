using Business.Concrete;
using Business.Constants;
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
            //GetColorById();
            //GetAllBrand();
            //Araç Eklemesi
            //GetByIdCar()
            //Araç silinmesi
            //DeleteCar(carManager);
            //Araç Güncelemesi
            //UpdateCar(carManager)
            //JoinMethod();
            //AddBrand();
            //DeleteBrand();
            //AddColor();
            //DeleteColor();
            //CarTest();
            //Addusers();
            //Addcustomers();
            //RentalAdd();
            //AOP--Uygulamanın başında ya da sonunda çalışması istenen kodların dizayn edilmesi.
            //Invocation -- Metod
        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental
            {
                CarId = 15,
                CustomerId = 3,
                RentalId = 3,
                RentDate = new DateTime(2023, 5, 28),
                ReturnDate = new DateTime(2023, 5, 29)
            });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void Addcustomers()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer1 = new Customer();

            customer1.CustomerId = 1; // bizim tarafımızdan verilecek id
            customer1.UserId = 1; //sistem tarafından verilecek oto id
            customer1.CompanyName = "Test";
            customerManager.Add(customer1);
        }

        private static void Addusers()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user1 = new User();

            user1.FirstName = "Engin";
            user1.LastName = "Salih";
            user1.Email = "enginsalih@gmail.com";
            user1.Password = "password2";
            userManager.Add(user1);
        }




        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "--" + car.DailyPrice + "--" + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }




        //private static void DeleteColor()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    Color colorToDelete = colorManager.GetColorById(3);
        //    colorManager.Delete(colorToDelete);
        //}

        //private static void AddColor()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    Color color = new Color();
        //    color.Name = "turquoise";
        //    colorManager.Add(color);
        //}

        //private static void DeleteBrand()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());

        //    Brand brandToDelete = brandManager.GetBrandById(6);
        //    brandManager.Delete(brandToDelete);
        //}

        //private static void AddBrand()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    Brand brand = new Brand();
        //    brand.Name = "Tesla";
        //    brandManager.Add(brand);
        //}

        //private static void JoinMethod()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarDetails())
        //    {
        //        Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
        //    }
        //}

        //private static void GetColorById()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    foreach (var colors in colorManager.GetAll().Where(c => c.Id == 5))
        //    {
        //        Console.WriteLine(colors.Name);
        //    }
        //}

        //private static void GetAllBrand()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    foreach (var brands in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brands.Name);
        //    }
        //}

        //private static void GetByIdCar()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarsByBrandId(3))
        //    {
        //        Console.WriteLine(car.CarName);
        //    }
        //}

        //private static void UpdateCar(CarManager carManager)
        //{
        //    foreach (var car in carManager.GetAll().Where(c => c.BrandId == 3).ToList())
        //    {
        //        car.CarName = "Toyota Supra";
        //        carManager.Update(car);
        //        Console.WriteLine("Araç Güncellendi:" + car.CarName);
        //    }
        //}

        //private static void DeleteCar(CarManager carManager)
        //{
        //    foreach (var car in carManager.GetAll().Where(c => c.BrandId == 17).ToList())
        //    {
        //        carManager.Delete(car);
        //        Console.WriteLine("Araç silindi:" + car.CarName);
        //    }
        //}
    }
}



//IEntity ve IEntityRepository'leri Core'a aldık ve diğer katmanları düzenledik(Entities)