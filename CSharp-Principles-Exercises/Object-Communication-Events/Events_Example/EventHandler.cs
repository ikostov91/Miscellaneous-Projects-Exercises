using System;

namespace Events_Example
{
    public class EventHandler
    {
        private EventPublisher eventPublisher;

        public EventHandler(EventPublisher eventPublisher)
        {
            this.eventPublisher = eventPublisher;
            eventPublisher.PrintDelegateHandler += HandleEvent;
        }

        public void HandleEvent(object sender, CustomEventArgs eventArgs)
        {
            string parameter = eventArgs.SomeParameter;
            Console.WriteLine($"PARAMETER: {parameter}");
        }
    }
}
