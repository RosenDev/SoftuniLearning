﻿using System;
using System.Collections.Generic;
using System.Text;
using SIS.WebServer.ViewEngine;

namespace SIS.WebServer.ViewEngine
{
    using System.IO;

    public abstract class ViewWidget : IViewWidget
    {
        private const string WidgetFolderPath = "Views/Shared/Validation/";
        private const string WidgetExtension = ".vwhtml";

        public string Render()
        {
            return File.ReadAllText($"{WidgetFolderPath}{this.GetType().Name}{WidgetExtension}");
        }
    }
}