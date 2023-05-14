using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetColorById(int id);
        void Add(Color Color);
        void Delete(Color Color);
        void Update(Color color);
    }
}
