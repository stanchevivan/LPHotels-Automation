using System;
using System.Collections.Generic;

namespace Tests.API.Framework
{
    public class SessionException : SystemException
    {
        public SessionException(string key, ArgumentException inner)
        {
            Message = $"{inner.Message} \nkey = {key}";
        }

        public SessionException(string key, KeyNotFoundException inner)
        {
            Message = $"{inner.Message} \nkey = {key}";
        }

        public override string Message { get; }
    }
}
