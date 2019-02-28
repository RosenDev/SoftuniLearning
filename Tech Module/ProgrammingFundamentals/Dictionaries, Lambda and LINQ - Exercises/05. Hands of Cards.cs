using System;
using System.Collections.Generic;
using System.Linq;
class _08_10_HandsOfCards
{
    private static object item;
    private static object outerPair;
    static void Main()
    {
        Dictionary<string, HashSet<int>> setMasiv1 = new Dictionary<string, HashSet<int>>();
        string inputStr = "";
        while (true)
        {
            inputStr = Console.ReadLine();/////
            if (inputStr == "JOKER")
            {
                break;
            }
            string[] myArr = inputStr.Split(new char[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string personName = myArr[0];
            if (!setMasiv1.ContainsKey(personName))
            {
                setMasiv1.Add(personName, new HashSet<int>());
            }
            for (int i = 1; i < myArr.Length; i++)
            {
                setMasiv1[personName].Add(kalk(myArr[i]));
            }/////
        }
        Console.WriteLine();
        foreach (var outerPair in setMasiv1)
        {
            int sum = 0;
            foreach (var innerPair in outerPair.Value)
            {
                sum += innerPair;
            }
            Console.WriteLine($"{outerPair.Key}: {sum}");
        }
        Console.WriteLine();/////
    }
    private static int Sum()
    {
        throw new NotImplementedException();
    }
    public static int showNum(string str)
    {//(S -> 4, H-> 3, D -> 2, C -> 1).
        int sum = 0, m = 0, length = str.Trim().Length;
        // char ch = str.Trim()[length - 1];
        string substring = str.Trim().Substring(0, length - 1).Trim();
        if (substring == "J" || substring == "Q" || substring == "K" || substring == "A")
        {
            m = n(substring);
        }
        else
        {
            int p = int.Parse(substring);
            m = p;
        }
        sum += m;
        return sum;
    }
    public static int kalk(string str)
    {//(S -> 4, H-> 3, D -> 2, C -> 1).
        int sum = 0, m = 0;
        int length = str.Trim().Length;
        char ch = str.Trim()[length - 1];
        string substring = str.Trim().Substring(0, length - 1).Trim();
        if (substring == "J" || substring == "Q" || substring == "K" || substring == "A")
        {
            m = n(substring) * n(ch);
        }
        else
        {
            int p = int.Parse(substring);
            m = p * n(ch);
        }
        sum += m;
        return sum;
    }
    public static int n(char ch)
    {
        int sum = 0, s = 4, h = 3, d = 2, c = 1;
        if (ch == 'S') sum = s;
        else if (ch == 'H') sum = h;
        else if (ch == 'D') sum = d;
        else if (ch == 'C') sum = c;
        return sum;
    }
    public static int n(string str)
    {
        int sum = 0, j = 11, q = 12, k = 13, a = 14;
        if (str == "J") sum = j;
        else if (str == "Q") sum = q;
        else if (str == "K") sum = k;
        else if (str == "A") sum = a;
        return sum;
    }
}