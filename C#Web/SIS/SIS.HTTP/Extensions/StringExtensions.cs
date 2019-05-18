using System.Linq;
using System.Text;

namespace SIS.HTTP.Extensions
{
    public  static class StringExtensions
    {
        public static string Capitalize(this string txt)
        {
            var sb = new StringBuilder();
            sb.Append(txt[0].ToString().ToUpper());
            sb.Append(txt.Skip(0).ToString().ToLower());
            return sb.ToString();
        }
    }
}