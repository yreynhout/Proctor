namespace Proctor
{
    public class ProcessFlow
    {
        private readonly ProcessFlowHandler[] _handlers;

        public ProcessFlow(ProcessFlowHandler[] handlers)
        {
            _handlers = handlers;
        }

        public ProcessFlowHandler[] Handlers
        {
            get { return _handlers; }
        }
    }
}