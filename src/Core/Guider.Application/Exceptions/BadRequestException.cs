﻿namespace Guider.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string msg) : base(msg) { }
    }
}