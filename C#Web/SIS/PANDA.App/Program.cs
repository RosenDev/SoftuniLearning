using SIS.MvcFramework;

namespace PANDA.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
          WebHost.Start(new Startup());
        }
    }
}
