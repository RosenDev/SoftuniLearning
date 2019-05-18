using System;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException:Exception
    {
        public InternalServerErrorException(string msg= "The Server has encountered an error.") :base(msg)
        {
            
        }
    }
}