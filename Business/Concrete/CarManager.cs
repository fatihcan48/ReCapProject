using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Aspects.Autofac.Validation.ValidationAspect;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("admin,product.add",Priority =1)]
        [ValidationAspect(typeof(CarValidator),Priority =2)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.get")]
        public IResult Add(Car car)
        {         
             _carDal.Add(car);
             return new SuccessResult(Messages.ProductAdded); 
        }

        
        [CacheRemoveAspect("ICarService.get",Priority =2)]
        [TransactionScopeAspect(Priority =1)]
        public IResult Delete(Car car)
        {
            if (car.Id!=null)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.ProductDeleted);
            }
            else
                return new ErrorResult(Messages.InvalidProductEntry);
            
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(byte Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==Id));
        }
       
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(byte Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == Id));
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
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

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }
    }
}
