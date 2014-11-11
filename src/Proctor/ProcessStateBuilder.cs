using System;
using System.Linq;

namespace Proctor
{
    public class ProcessStateBuilder<TState>
    {
        private readonly Func<object> _factory;
        private readonly ProcessStateHandler[] _handlers;

        public ProcessStateBuilder(TState initialState)
        {
            _factory = () => initialState;
            _handlers = new ProcessStateHandler[0];
        }

        public ProcessStateBuilder(Func<TState> factory)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            _factory = () => factory();
            _handlers = new ProcessStateHandler[0];
        }

        ProcessStateBuilder(Func<object> factory, ProcessStateHandler[] handlers)
        {
            _factory = factory;
            _handlers = handlers;
        }

        public ProcessStateBuilder<TState> When<TMessage>(Func<TState, TMessage, TState> handler)
        {
            if (handler == null) throw new ArgumentNullException("handler");
            return new ProcessStateBuilder<TState>(
                _factory,
                _handlers.
                    Concat(new[]
                    {
                        new ProcessStateHandler(
                            typeof (TMessage),
                            (state, message) => handler((TState) state, (TMessage) message))
                    }).
                    ToArray()
                );
        }

        public ProcessState Build()
        {
            return new ProcessState(_factory, _handlers);
        }
    }
}