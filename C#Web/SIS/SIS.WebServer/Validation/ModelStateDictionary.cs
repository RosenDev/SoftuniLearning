using System.Collections.Generic;
using System.Collections.Immutable;

namespace SIS.WebServer.Validation
{
    public class ModelStateDictionary
    {
        private readonly IDictionary<string, List<string>> errorMessages;

        public IReadOnlyDictionary<string, List<string>> ErrorMessage
            => errorMessages.ToImmutableDictionary();

        public ModelStateDictionary()
        {
            errorMessages=new Dictionary<string, List<string>>();
        }

        public bool IsValid => errorMessages.Count == 0;

        public void Add(string propertyName, string errorMessage)
        {
            if (!errorMessages.ContainsKey(propertyName))
            {
                errorMessages.Add(propertyName,new List<string>(){errorMessage});
            }
            else
            {
                errorMessages[propertyName].Add(errorMessage);
            }
        }

    }
}