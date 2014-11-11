using System;

namespace Proctor
{
    public class ProcessStateHandler
    {
        private readonly Type _message;
        private readonly Func<object, object, object> _handler;

        public ProcessStateHandler(Type message, Func<object, object, object> handler)
        {
            _message = message;
            _handler = handler;
        }

        public Type Message
        {
            get { return _message; }
        }

        public Func<object, object, object> Handler
        {
            get { return _handler; }
        }
    }
}
