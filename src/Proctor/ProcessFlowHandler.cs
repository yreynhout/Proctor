using System;
using System.Collections.Generic;

namespace Proctor
{
    public class ProcessFlowHandler
    {
        private readonly Type _message;
        private readonly Func<object, object, IEnumerable<object>> _handler;

        public ProcessFlowHandler(Type message, Func<object, object, IEnumerable<object>> handler)
        {
            _message = message;
            _handler = handler;
        }

        public Type Message
        {
            get { return _message; }
        }

        public Func<object, object, IEnumerable<object>> Handler
        {
            get { return _handler; }
        }
    }
}