using System;
using System.Linq;
using System.Collections.Generic;
using System.Dynamic;

namespace listsExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var theList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var results=new List<int>();
            while (true)
            {
                var cmd = Console.ReadLine().Split(' ');
                if (cmd[0]=="Delete")
                {
                    var indexOf = int.Parse(cmd[1]);
                    theList.RemoveAll(m => m.Equals(indexOf));

                    //for (int i = 0; i < theList.Count; i++)
                    //{
                    //    if (theList[i]==indexOf)
                    //    {
                    //        theList.Remove(indexOf);

                    //    }
                    //}
                    
                }
                else if (cmd[0]=="Insert")
                {
                    var element = int.Parse(cmd[1]);
                    var indexOf = int.Parse(cmd[2]);
                    theList.Insert(indexOf,element);

                }
                else if (cmd[0]=="Even")
                {
                    for (int i = 0; i < theList.Count; i++)
                    {
                        if (theList[i]%2==0)
                        {
                            
                            results.Add(theList[i]);
                            
                            
                        }
                      
                        
                    }
                    break;
                    

                }else if (cmd[0]=="Odd")
                {
                    for (int i = 0; i < theList.Count; i++)
                    {

                        if (theList[i] % 2 != 0)
                        {

                            results.Add(theList[i]);


                        }
                    }

                    break;

                }


            }

            Console.WriteLine(string.Join(" ",results));

        }
    }
}
