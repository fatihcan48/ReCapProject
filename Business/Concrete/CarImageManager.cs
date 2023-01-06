using Business.Abstract;
using Business.Constants;
using Core.BusinessRules;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.DataResults;
using Core.Utilities.Helpers;
using Core.Utilities.VoidResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        private string ImagesPath = "wwwroot\\Images\\";

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (!result.Success)
            {
                return result;
            }

            // Adding Image
            var imageResult = FileHelper.Add(file);
            carImage.ImagePath = imageResult.Message;
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var carToBeDeleted = _carImageDal.Get(c => c.ImageId == carImage.ImageId);
            if (carToBeDeleted == null)
            {
                return new ErrorResult();
            }
            FileHelper.Delete(carToBeDeleted.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var carToBeUpdated = _carImageDal.Get(c => c.ImageId == carImage.ImageId);
            if (carToBeUpdated == null)
            {
                return new ErrorResult();
            }
            var imageResult = FileHelper.Update(file, carToBeUpdated.ImagePath);
            carImage.ImagePath = imageResult.Message;
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetByCarId(byte carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result == 0)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == imageId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage(byte carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultLogo.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

       
    }
}
