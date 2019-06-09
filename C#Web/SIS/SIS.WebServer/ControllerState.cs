using SIS.WebServer.Validation;

namespace SIS.WebServer
{
    public class ControllerState:IControllerState
    {
        public ModelStateDictionary ModelState { get; set; }

        public ControllerState()
        {
            Reset();
        }
        public void Reset()
        {
            ModelState=new ModelStateDictionary();
        }

        public void Initialize(Controller controller)
        {
            ModelState = controller.ModelState;
        }

        public void SetState(Controller controller)
        {
             controller.ModelState=ModelState;
        }
    }
}