namespace SIS.WebServer.Attributes.Validation
{
    public class RequiredAttribute:ValidationAttribute
    {
        public RequiredAttribute(string errorMessage="This field is required!"):base(errorMessage)
        {
            
        }

       
        public override bool IsValid(object value)
        {
            if (value is string str)
            {
                return str != "";
            }

            return value != null;
        }
    }
}