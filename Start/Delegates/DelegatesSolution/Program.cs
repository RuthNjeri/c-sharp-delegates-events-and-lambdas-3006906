using System;

namespace DelegatesSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            ShippingFeesDelegate theDel;
            ShippingDestination theDest;
            string zone;

            do {
                Console.WriteLine("Enter the shipping zone: ");
                zone = Console.ReadLine();

                if (!zone.Equals("exit"))
                {
                    theDest = ShippingDestination.getDestinationInfo(zone);

                    if(theDest != null)
                    {
                        Console.WriteLine("Item Price");
                        decimal price = decimal.Parse(Console.ReadLine());

                        theDel = theDest.calcFees;

                        if(theDest.m_isHighRisk)
                        {
                            theDel += delegate (decimal price, ref decimal fee)
                            {
                                fee += 25.0m;
                            };
                        }

                        decimal fee = 0.0m;
                        theDel(price, ref fee);
                        Console.WriteLine("The shipping fee {0}", fee);
                    }
                    else
                    {
                        Console.WriteLine("You have entered wrong dest");
                    }
                }
            } while ( zone != "exit" );
        }
    }
}
