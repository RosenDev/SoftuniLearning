

namespace SIS.WebServer
{
    using Validation;

    public interface IControllerState
    {
        ModelStateDictionary ModelState { get; set; }

        void Reset();

        void Initialize(BaseController controller);

        void SetState(BaseController controller);
    }
}