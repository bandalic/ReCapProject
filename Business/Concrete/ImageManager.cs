using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        IFileHelper _fileHelper;
        public ImageManager(IImageDal imageDal, IFileHelper fileHelper)
        {
            _imageDal = imageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, Image image)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(image.CarId));
            if (result != null)
            {
                return result;
            }
            image.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(Image image)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + image.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetImagesByCarId(int CarId)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(i => i.Id == CarId), Messages.ImagesListed);
        }

        public IResult Update(IFormFile file, Image image)
        {
            image.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + image.ImagePath, PathConstants.ImagesPath);
            _imageDal.Update(image);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageLimit(int id)
        {
            var result = _imageDal.GetAll(c => c.CarId == id).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
