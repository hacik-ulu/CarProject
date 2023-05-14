using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color Color)
        {
            _colorDal.Add(Color);
        }

        public void Delete(Color Color)
        {
            _colorDal.Delete(Color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetColorById(int id)
        {
            return _colorDal.Get(c => c.Id == id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
