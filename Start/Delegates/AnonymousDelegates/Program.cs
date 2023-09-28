using System;

namespace AnonymousDelegates
{
    public delegate string MyDelegate(int arg1, int arg2);

    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Implement an anonymous delegate
            // inline delegates increase the readability. 
            MyDelegate del = delegate(int arg1, int arg2)
            {
                return (arg1 + arg2).ToString();
            };
            Console.WriteLine("The number from the anonymous delegate is: " + del(10, 20));
        }
    }
}
