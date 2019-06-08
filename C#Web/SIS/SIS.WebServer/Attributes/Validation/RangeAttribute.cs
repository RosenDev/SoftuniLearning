using System;

namespace SIS.WebServer.Attributes.Validation
{
    public class RangeAttribute:ValidationAttribute
    {
        private readonly object minValue;
        private readonly object maxValue;
        private readonly Type objectType;

        public RangeAttribute(int minValue, int maxValue, string errorMessage)
            : base(errorMessage)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.objectType = typeof(int);
        }

        public RangeAttribute(double minValue, double maxValue, string errorMessage)
            : base(errorMessage)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.objectType = typeof(double);
        }

        public RangeAttribute(Type type, string minValue, string maxValue, string errorMessage)
            : base(errorMessage)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.objectType = type;
        }

        public override bool IsValid(object value)
        {
            if (objectType == typeof(int))
            {
                return (int)value >= (int)minValue && (int)value <= (int)maxValue;
            }

            if (objectType == typeof(double))
            {
                return (double)value >= (double)minValue && (double)value <= (double)maxValue;
            }

            if (objectType == typeof(decimal))
            {
                return (decimal)value >= (decimal)minValue && (decimal)value <= (decimal)maxValue;
            }

            return false;
        }
    }
}