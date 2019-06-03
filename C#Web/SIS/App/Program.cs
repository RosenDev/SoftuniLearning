
using SIS.WebServer;

namespace App
{
    
   public class Program
    {
      public static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
