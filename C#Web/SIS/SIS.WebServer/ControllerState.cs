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

        public void Initialize(BaseController controller)
        {
            ModelState = controller.ModelState;
        }

        public void SetState(BaseController controller)
        {
             controller.ModelState=ModelState;
        }
    }
}