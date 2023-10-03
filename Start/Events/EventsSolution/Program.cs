using System;

namespace EventsSolution
{    
    class Program
    {
        static event Action<int> savingsChanged;
        static void Main(string[] args)
        {

            int deposit;
            int balance = 0;
            int savingsGoal = 510;
            string input;
            
            savingsChanged += (balance) =>
            {
                if(balance == savingsGoal)
                {
                    Console.WriteLine("You have reached your goal! You have {0}", savingsGoal);
                }
            };

            do 
            {
                Console.WriteLine("How much to deposit?");
                input = Console.ReadLine();
                if (!input.Equals("exit"))
                {
                    deposit = int.Parse(input);
                    balance += deposit;
                    Console.WriteLine("The balance amount is {0}", balance);
                    savingsChanged?.Invoke(balance);
                } 
            }while (!input.Equals("exit"));
            Console.WriteLine("Goodbye!");
        }
    }
}
