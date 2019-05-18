using SIS.HTTP.Common;

namespace SIS.HTTP.Headers
{
    public class HttpHeader
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return $"{Key}: {Value}";
        }

        public HttpHeader(string key, string value)
        {
            CoreValidator.ThrowIfEmpty(key,nameof(key));
            CoreValidator.ThrowIfEmpty(value,nameof(value));
            Key = key;
            Value = value;
        }
    }
}