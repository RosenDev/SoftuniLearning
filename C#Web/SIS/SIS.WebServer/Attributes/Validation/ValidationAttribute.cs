using System;

namespace SIS.WebServer.Attributes.Validation
{
    /// <summary>
    /// The base Attribute used for validations in SIS Framework
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValidationAttribute : Attribute
    {
        protected ValidationAttribute(string errorMessage = "Error Message")
        {
            this.ErrorMessage = errorMessage;
        }
        /// <summary>
        /// The message that will be shown when model is not valid
        /// </summary>
        public string ErrorMessage { get; }
        /// <summary>
        /// Validate model property
        /// </summary>
        /// <param name="value"></param>
        /// <returns>bool</returns>
        public abstract bool IsValid(object value);
    }
}