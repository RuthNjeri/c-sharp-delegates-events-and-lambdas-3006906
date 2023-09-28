using System;

namespace BasicDelegates
{
    // TODO: declare the delegate type
    public delegate string MyDelegate(int arg1, int arg2);

    class MyClass
    {
        // Delegates can be bound to instance members as well as
        // static class functions
        public string instanceMethod1(int arg1, int arg2)
        {
            return ((arg1 + arg2) * arg1).ToString();
        }
    }

    class Program
    {
        // TODO: Create functions to serve as delegate implementations
        static string func1(int a, int b)
        {
            return (a + b).ToString();
        }

        
        static string func2(int a, int b)
        {
            return (a * b).ToString();
        }

        static void Main(string[] args)
        {
            // TODO: exercise each delegate function
            MyDelegate del1 = new MyDelegate(func1);
            Console.WriteLine("The number from func 1 is: " + del1(10, 20));

            del1 = new MyDelegate(func2);
            Console.WriteLine("The number from func 2 is: " + del1(10, 20));


            // TODO: Use an instance function of a class as a delegate
            del1 = new MyDelegate(new MyClass().instanceMethod1);
            Console.WriteLine("The number from instanceMethod1 is: " + del1(10, 20));

        }
    }
}

