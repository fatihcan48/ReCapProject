using Core.Entities;
using Core.Utilities.Abstract;
using Core.Utilities.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService 
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetCarsByBrandId(byte brandId);
        IDataResult<List<Car>> GetCarsByColorId(byte colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
    }
}
