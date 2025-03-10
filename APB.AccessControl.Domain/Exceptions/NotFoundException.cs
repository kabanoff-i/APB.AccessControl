﻿using System;

namespace APB.AccessControl.Domain.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException():base()
        { }
        public NotFoundException(string message) : base(message)
        { }

        public NotFoundException(string message, Exception ex) : base(message, ex)
        { }
    }
}