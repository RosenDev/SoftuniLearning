using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.ViewEngine
{
    public interface IViewWidget
    {
        string Render();
    }
}