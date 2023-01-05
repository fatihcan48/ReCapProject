using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car(){ Id=1, BrandId=1, ColorId=1, ModelYear=2018, DailyPrice=200, Description="Dizel, Otomatik vites"},
                new Car(){ Id=2, BrandId=1, ColorId=2, ModelYear=2015, DailyPrice=180, Description="Benzin, Otomatik vites"},
                new Car(){ Id=3, BrandId=2, ColorId=3, ModelYear=2020, DailyPrice=250, Description="Dizel, Manuel vites"},
                new Car(){ Id=4, BrandId=2, ColorId=1, ModelYear=2012, DailyPrice=150, Description="Benzin, Otomatik vites"},
                new Car(){ Id=5, BrandId=3, ColorId=3, ModelYear=2021, DailyPrice=250, Description="Benzin, Manuel vites"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Araç veritabanına eklendi.");
        }

        public void Delete(Car car)
        {
            var toDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(toDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _cars.SingleOrDefault(c => c.Id == 2);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetById(int ID)
        {
            return _cars.Where(c => c.Id==ID).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var toUpdate = _cars.SingleOrDefault(c => c.Id==car.Id);

            toUpdate.DailyPrice = car.DailyPrice;
            toUpdate.Description = car.Description;  
        }

    }
}
