using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Data;

public class Program
{
    public static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());

        
        List<Car> _cars = new List<Car>();
        {

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);

            }

            





        }
    }
}






