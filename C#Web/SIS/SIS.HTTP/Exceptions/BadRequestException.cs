using System;

namespace SIS.HTTP.Exceptions
{
    public class BadRequestException:Exception
    {
        public BadRequestException(string msg= "The Request was malformed or contains unsupported elements.") :base(msg)
        {
            
        }
    }
}