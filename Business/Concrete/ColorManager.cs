﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager 
    {
        IColorDal _colorDal;
        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

       

        public List<Color> GetCarsByColorId(int id)
        {
            return _colorDal.GetAll(c => c.ColorId == id);
        }
    }
}
