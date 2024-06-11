using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Data;

public class Program
{
    public static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryCarDal());

        
        List<Car> _cars = new List<Car>();
        {

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(" Marka: " + car.BrandName);

            }

             static void Main()
            {
      

                Car newCar1 = new Car
               
                {
                    Id = 7,
                    BrandId = 4,
                    ColorId = 12,
                    DailyPrice = 8,
                    Description = "Cheap Car",
                    ModelYear = 2023,
                    BrandName = "C"
                };
                InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
                inMemoryCarDal.Add(newCar1);

            }

        }
    }
}






