﻿using System;
using System.Collections.Generic;
using System.Text;

namespace APB.AccessControl.Shared.Models.Common
{

    public class Error
    {
        public Error(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public static Error None => new Error(string.Empty);

        public static implicit operator Error(string message) => new Error(message);

        public static implicit operator string(Error error) => error.Message;
    }
}
