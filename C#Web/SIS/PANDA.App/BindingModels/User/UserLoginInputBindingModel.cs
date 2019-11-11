using SIS.MvcFramework.Attributes.Validation;

namespace PANDA.App.BindingModels.User
{
    public class UserLoginInputBindingModel
    {
        [RequiredSis]
        public string Username { get; set; }
        [RequiredSis]
        public string Password { get; set; }
    }
}