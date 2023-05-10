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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList() // filtre yoksa çalışır
                    : context.Set<Color>().Where(filter).ToList(); // filtre varsa çalışır.
            }
        }

        

        public List<Color> GetColorsByColorId(int colorId)
        {
            using (ProjectDatabaseContext context = new ProjectDatabaseContext())
            {
                var colors = context.Colors.Where(b => b.Equals(colorId)).ToList();
                return colors;
            }
        }

        public void Update(Color entity)
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
