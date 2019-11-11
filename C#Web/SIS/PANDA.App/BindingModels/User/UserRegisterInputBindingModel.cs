using SIS.MvcFramework.Attributes.Validation;

namespace PANDA.App.BindingModels.User
{
    public class UserRegisterInputBindingModel
    {
        [RequiredSis]
        public string Username { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }

        [EmailSis]
        [RequiredSis]
        public string Email { get; set; }

    }
}