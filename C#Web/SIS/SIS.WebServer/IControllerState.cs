

namespace SIS.WebServer
{
    using Validation;

    public interface IControllerState
    {
        ModelStateDictionary ModelState { get; set; }

        void Reset();

        void Initialize(Controller controller);

        void SetState(Controller controller);
    }
}