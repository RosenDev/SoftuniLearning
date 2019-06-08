using System;

namespace SIS.WebServer.Attributes.Validation
{
    public class StringLengthAttribute:ValidationAttribute
    {
        private int maxLength;
        private int minLength;
  
        public StringLengthAttribute(int maxLength,int minLength=0,string errorMessage=null):base(errorMessage)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }
        public override bool IsValid(object value)
        {
            if (value is string text)
            {
                return text.Length <= maxLength && text.Length >= minLength;
            }

            throw new InvalidCastException("the value is not of type string");
        }
    }
}