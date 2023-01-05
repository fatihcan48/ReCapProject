using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.DataResults;
using Core.Utilities.VoidResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Aspects.Autofac.Validation.Class1;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
                       
             _carDal.Add(car);
             return new SuccessResult(Messages.ProductAdded); 
        }

        public IResult Delete(Car car)
        {
            if (car.Id>0)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.ProductDeleted);
            }
            else
                return new ErrorResult(Messages.InvalidProductEntry);
            
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        public IDataResult<List<Car>> GetCarsByBrandId(byte brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(byte colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }
        public IResult Update(Car car)
        {
            if (car.ModelName.Length>2 && car.DailyPrice>0 && car.ModelYear>1999 )
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.ProductUpdated);
            }
            else
            {
                return new ErrorResult(Messages.InvalidProductEntry);
            }
            
        }
        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }
    }
}
