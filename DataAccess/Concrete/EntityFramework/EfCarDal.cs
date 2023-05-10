using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                //Eşleşme durumu var mı diye kontrol edilir.
                //State ile durum kontrolü
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                if (filter == null)
                {
                    return context.Set<Car>().ToList(); // filtre varsa çalışır.
                }
                else
                {
                    return context.Set<Car>().Where(filter).ToList(); // filtre varsa çalışır.
                } // filtre varsa çalışır.
            }
        }


        public void Update(Car entity)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
