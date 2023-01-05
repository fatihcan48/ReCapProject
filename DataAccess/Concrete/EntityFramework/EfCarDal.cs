using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join
                             b in context.Brands on c.BrandId equals b.BrandId
                             join
                             k in context.Colors on c.ColorId equals k.ColorId
                             select new CarDetailsDto
                             {
                                 Id = c.Id,
                                 ModelName = c.ModelName,
                                 BrandName = b.BrandName,
                                 ModelYear=c.ModelYear,
                                 DailyPrice=c.DailyPrice,   
                                 ColorName = k.ColorName                                
                             };

                return result.ToList();
                             
            }
        }
    }
}
