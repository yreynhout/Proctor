using System;
using System.Collections.Generic;
using System.Linq;

namespace Proctor
{
    public class ProcessFlowBuilder<TState>
    {
        private readonly ProcessFlowHandler[] _handlers;

        public ProcessFlowBuilder()
        {
            _handlers = new ProcessFlowHandler[0];
        }

        ProcessFlowBuilder(ProcessFlowHandler[] handlers)
        {
            _handlers = handlers;
        }

        public ProcessFlowBuilder<TState> When<TMessage>(Func<TState, TMessage, IEnumerable<object>> handler)
        {
            if (handler == null) throw new ArgumentNullException("handler");
            return new ProcessFlowBuilder<TState>(
                _handlers.
                    Concat(new[]
                    {
                        new ProcessFlowHandler(
                            typeof (TMessage),
                            (state, message) => handler((TState) state, (TMessage) message)),
                    }).
                    ToArray()
                );
        }

        public ProcessFlow Build()
        {
            return new ProcessFlow(_handlers);
        }
    }
}