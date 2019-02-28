using System;
using System.Collections.Generic;

namespace LambdaExercise
{
    class Program
    {
        static void Main()
        {
           /*
            var itemsTable = new Dictionary<string,int>();
            var item = Console.ReadLine();
            var quantity = int.Parse(Console.ReadLine());
            while (item!="stop")
            {
                if (itemsTable.ContainsKey(item))
                {
                    itemsTable[item] += quantity;


                }
                else
                {
                    itemsTable.Add(item,quantity);
                }

                item = Console.ReadLine();
                if (item!="stop")
                {
                    quantity = int.Parse(Console.ReadLine());
                }
                

            }

            foreach (var VARIABLE in itemsTable)
            {
                Console.WriteLine($"{VARIABLE.Key} -> {VARIABLE.Value}");
            } */




            var  clientData = new Dictionary<string,string>();

            var name = Console.ReadLine();
            var mail = "";
            if (name=="stop")
            {
                return;
            }
            else
            {
                mail = Console.ReadLine();
            }

            while (name != "stop")
            {
                if (mail.Contains(".bg"))
                {
                    if (clientData.ContainsKey(name))
                    {
                        clientData[name] = mail;

                    }
                    else
                    {
                        clientData.Add(name, mail);
                    }


                }

                name = Console.ReadLine();
                if (name!="stop")
                {
                    mail = Console.ReadLine();
                }
               


            }

            foreach (var client in clientData)
            {
                Console.WriteLine($"{client.Key} -> {client.Value}");
                
            }
        }

    }

}
    
