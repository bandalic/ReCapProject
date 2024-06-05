using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System.Data;

public class Program
{
    public static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryCarDal());
        foreach (var car in carManager.GetAll())
        {
            Console.WriteLine("Marka: " + car.Description);
            

        }
    }

   

}




