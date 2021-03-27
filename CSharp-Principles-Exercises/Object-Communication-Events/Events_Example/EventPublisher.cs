namespace Events_Example
{
    public class EventPublisher
    {
        public delegate void PrintDelegate(object sender, CustomEventArgs eventArgs);
        public event PrintDelegate PrintDelegateHandler;

        public void RaiseEvent(string parameter)
        {
            this.PrintDelegateHandler?.Invoke(this, new CustomEventArgs(parameter));
        }
    }
}
