using System;
using System.Collections.Generic;

namespace LambdaExercise
{
    class Program
    {
        static void Main()
        {
            var itemsTable = new Dictionary<string,int>();
            var item = Console.ReadLine();
          var quantity=0;
           if(item=="stop"){
             
             return;}else{
              quantity = int.Parse(Console.ReadLine());}
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
            }

        }

    }

}