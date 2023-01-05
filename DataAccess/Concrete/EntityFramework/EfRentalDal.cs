using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join k in context.Customers on r.CustomerId equals k.CustomerId
                             join u in context.Users on k.UserId equals u.UserId
                             select new RentalDetailDto()
                             { 
                                 RentId = r.RentId, 
                                 CarId = c.Id,
                                 ModelName = c.ModelName,
                                 CustomerId=k.CustomerId,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 CompanyName=k.CompanyName,
                                 RentDate=r.RentDate,
                                 
                             };

                return result.ToList();

            }

        }
    }
}
