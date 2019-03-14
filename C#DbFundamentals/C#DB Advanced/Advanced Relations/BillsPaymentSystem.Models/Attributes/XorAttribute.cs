using System;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XorAttribute : ValidationAttribute
    {
        private string xorTargetAttribute;
        public XorAttribute(string xorTargetAttribute)
        {
            this.xorTargetAttribute = xorTargetAttribute;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var target = validationContext.ObjectType.GetProperty(xorTargetAttribute)
                .GetValue(validationContext.ObjectInstance);
            if ((target==null&&value!=null)||
                (target!=null&&value==null))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The two properties have opposite values");
        }
    }
}