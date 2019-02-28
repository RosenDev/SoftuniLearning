using System;
 
namespace Hotel
{
    class Hotels
    {
        static void Main(string[] args)
        {
            string monthVisit = Console.ReadLine(); //May, June, July, August, September, October or December
            int nigthsRest = int.Parse(Console.ReadLine());
            double studioPrice = 0.0;
            double doubleRoomPrice = 0.0;
            double suitePrice = 0.0;
            double discount = 0.0;
            switch (monthVisit)
            {
                case "May":
                case "October":
                    studioPrice = 50.0;
                    if (nigthsRest > 7)
                    {
                        studioPrice *= 0.95;
                    }
                    if (nigthsRest > 7 && monthVisit == "October")
                    {
                        studioPrice *= (double)(nigthsRest - 1) / nigthsRest;
                    }
                    doubleRoomPrice = 65.0;
                    suitePrice = 75.0;
                    break;
                case "June":
                case "September":
                    studioPrice = 60.0;
                    if (nigthsRest > 7 && monthVisit== "September")
                    {
                        studioPrice *= (double)(nigthsRest - 1) / nigthsRest;
                    }
                    doubleRoomPrice = 72.0;
                    if (nigthsRest>14)
                    {
                        doubleRoomPrice *= 0.90;
                    }
                    suitePrice = 82.0;
                    break;
                case "July":
                case "August":
                case "December":
                    studioPrice = 68.0;
                   
                    doubleRoomPrice = 77.0;
                    suitePrice = 89.0;
                    if(nigthsRest>14)
                    {
                        suitePrice *= 0.85;
                    }
                    break;
                default:break;
            }
            studioPrice *= nigthsRest;
            doubleRoomPrice *= nigthsRest;
            suitePrice *= nigthsRest;
            Console.WriteLine($"Studio: {studioPrice:F2} lv.");
            Console.WriteLine($"Double: {doubleRoomPrice:F2} lv.");
            Console.WriteLine($"Suite: {suitePrice:F2} lv.");
        }
    }
}