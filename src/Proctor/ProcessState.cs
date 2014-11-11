using System;

namespace Proctor
{
    public class ProcessState
    {
        private readonly Func<object> _factory;
        private readonly ProcessStateHandler[] _handlers;

        public ProcessState(Func<object> factory, ProcessStateHandler[] handlers)
        {
            _factory = factory;
            _handlers = handlers;
        }

        public Func<object> Factory
        {
            get { return _factory; }
        }

        public ProcessStateHandler[] Handlers
        {
            get { return _handlers; }
        }
    }
}