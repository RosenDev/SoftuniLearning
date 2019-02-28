using System;

namespace IfandLoops
{
    class Program
    {
        static void Main()
        {
            var word = Console.ReadLine();
            var currword ="";
            var readyword = "";
            if (word.EndsWith("y"))
            {
                currword = word.Remove(word.Length - 1);
                readyword = currword + "ies";
            }else if (word.EndsWith("z")|| word.EndsWith("o")|| word.EndsWith("ch")|| word.EndsWith("s")|| word.EndsWith("sh")|| word.EndsWith("x"))
            {

               
                readyword = word+ "es";

            }
            else
            {
                readyword = word + "s";
            }

            //o, ch, s, sh, x or z – add es 
            Console.WriteLine(readyword);

        }
    }
}
