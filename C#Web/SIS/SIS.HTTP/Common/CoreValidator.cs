﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Common
{
   public class CoreValidator
    {
        public static void ThrowIfNull(object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentException(name);
            }

        }
        public static void ThrowIfEmpty(string text, string name)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException($"{name} cannot be empty!");
            }
        }
    }
}