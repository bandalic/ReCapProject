using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>{
                new Car { Id = 1, BrandId = 1, ColorId = 13, DailyPrice = 30000, Description = "BMW 5.20", ModelYear = 2023, BrandName = "BMW"},
                new Car { Id = 2, BrandId = 1, ColorId = 13, DailyPrice = 28000, Description = "BMW 5.20", ModelYear = 2023, BrandName= "BMW"},
                new Car { Id = 3, BrandId = 3, ColorId = 10, DailyPrice = 25000, Description = "Mercedes C180", ModelYear = 2023, BrandName="Mercedes"},
                new Car { Id = 4, BrandId = 5, ColorId = 11, DailyPrice = 21000, Description = "Hyundai i20n", ModelYear = 2023, BrandName= "BMW"},
                new Car { Id = 5, BrandId = 3, ColorId = 10, DailyPrice = 40000, Description = "Mercedes A180", ModelYear = 2023, BrandName="Mercedes"},
            };
        }
        public void Add(Car car)
        {
            if (car.DailyPrice > 10 && car.BrandName.Length > 2)
            {
                _cars.Add(car);
            }
             else {
                Console.WriteLine("Error");
            }
           
            
          
            
        }
        public void Delete(Car car) 
        {
          Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c =>c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
}

    
    
    
    
    }


