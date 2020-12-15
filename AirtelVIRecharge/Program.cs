using System;

namespace AirtelVIRecharge
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                user myUser = new user(name: "Govind", brand: "idea", age: 12, contact: "+818698667843");
                Console.WriteLine("User Created");
                PlanSelector selector = new PlanSelector(myUser);
                Console.WriteLine("Selector Created");
                selector.ChangePlan(199, true, true);
                if(myUser.CurrentPlan == 99)
                {
                    Console.WriteLine("Plan changed!!!");
                    Console.WriteLine("New Plan is : {0}", myUser.CurrentPlan);
                }
                else 
                {
                    throw new Exception("Plan Not Changed!");
                }
            }

            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
