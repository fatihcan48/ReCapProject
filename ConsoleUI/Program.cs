using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            // CarManagerTest();

            // BrandTest();

            // ColorTest();


            Console.ReadKey();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var c in colorManager.GetAll().Data.OrderBy(c => c.ColorName))
            {
                Console.WriteLine(c.ColorName);
            }
            Console.WriteLine("\n**************\n");

            Console.WriteLine(colorManager.GetById(1).Data.ColorName);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var b in brandManager.GetAll().Data.OrderBy(p => p.BrandName))
            {
                Console.WriteLine(b.BrandName);
            }
            Console.WriteLine("\n**************\n");

            Console.WriteLine(brandManager.GetById(6).Data);
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0}-{1,-10}{2,-10}{3,-10}", item.Id, item.BrandName, item.ModelName, item.ColorName);
            }
            Console.WriteLine();

            //var result = carManager.Delete(new Car
            //{  
            //    Id=14
            //}).Message;

            //Console.WriteLine(result);
        }
    }
}