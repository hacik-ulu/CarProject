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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                return filter == null
                    ? context.Set<Brand>().ToList() // filtre yoksa çalışır
                    : context.Set<Brand>().Where(filter).ToList(); // filtre varsa çalışır.
            }
        }

        public List<Brand> GetCarsByBrandId(int brandId)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                var brands = context.Brands.Where(b => b.Equals(brandId)).ToList();
                return brands;
            }
        }

        public void Update(Brand entity)
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
